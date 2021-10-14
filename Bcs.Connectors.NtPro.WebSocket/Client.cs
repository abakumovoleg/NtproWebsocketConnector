using System;
using System.IO;
using System.Net.WebSockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bcs.Connectors.NtPro.WebSocket.Messages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Environment = Bcs.Connectors.NtPro.WebSocket.Messages.Environment;

namespace Bcs.Connectors.NtPro.WebSocket
{
    public class Client
    {
        private readonly Environment _environment;
        private readonly string _url;
        private readonly string _userName;
        private readonly string _password;
        private readonly ILogger<Client> _logger;
        private readonly int _timeout;
        private ClientWebSocket _ws;

        private ClientPhase _phase = ClientPhase.None;
        private Task _receive;
        private Task _check;
        private long _messageId = 1;
        private DateTime _lastMessageTime = DateTime.Now;
        private TaskFactory _taskFactory;
        
        private readonly Subject<NtProMessage> _onMessage = new Subject<NtProMessage>();
        private readonly Subject<object> _onConnected = new Subject<object>();

        private readonly SemaphoreSlim _loginSemaphore = new SemaphoreSlim(0,1);

        public IObservable<NtProMessage> OnMessage { get; }
        public IObservable<object> OnConnected { get; } 

        public Client(Environment environment, string url, string userName, string password, ILogger<Client> logger, int timeout = 5)
        {
            _environment = environment;
            _url = url;
            _userName = userName;
            _password = password;
            _logger = logger;
            _timeout = timeout;

            OnMessage = _onMessage;
            OnConnected = _onConnected;
        }

        public void Connect()
        {
            var scheduler = new ConcurrentExclusiveSchedulerPair();
            _taskFactory = new TaskFactory(scheduler.ExclusiveScheduler);
            _taskFactory.StartNew(ConnectInternal).Unwrap();
        } 

        public async Task WaitLogin()
        {
            await _loginSemaphore.WaitAsync();
        }

        public async Task SendOnExclusiveScheduler<TPayload>(TPayload payload)
            where TPayload : PayloadBase
        {
            await _taskFactory.StartNew(() => SendDataMessage(payload)).Unwrap();
        }

        private async Task ConnectInternal()
        {
            await EnsureConnected();

            try
            {
                _receive = Receive();
                _check = CheckConnection();

                await _receive;
                await _check;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        private Message GetDataMessage<TMessage>(TMessage message)
        {
            return new Message
            {
                Type = MessageType.Data,
                Msg = JsonConvert.SerializeObject(message, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                })
            };
        }

        private async Task EnsureConnected()
        {
            while (true)
            {
                try
                {
                    _logger.LogInformation("disposing");  

                    _ws?.Dispose();

                    _logger.LogInformation("disposed");

                    _ws = new ClientWebSocket();

                    var cts = new CancellationTokenSource(30000);

                    _logger.LogInformation("connecting");

                    await _ws.ConnectAsync(new Uri(_url), cts.Token);

                    if (_ws.State == WebSocketState.Open)
                    {
                        _logger.LogInformation("connected");
                         
                        await SendDataMessage(new HelloRequestPayload
                        {
                            Message = new HelloRequest()
                        });

                        _phase = ClientPhase.Auth;
                        return;
                    }
                    else
                    {
                        _logger.LogWarning($"{_ws.State} {_ws.CloseStatusDescription} {_ws.CloseStatus}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(1000);
            }
        }


        private async Task Receive()
        {
            var arrBuffer = new byte[2048];
            var buffer = new ArraySegment<byte>(arrBuffer);

            while (true)
            {
                if (_ws.State != WebSocketState.Open)
                {
                    await Task.Delay(1000);
                    continue;
                }

                try
                { 
                    using (var ms = new MemoryStream())
                    {
                        WebSocketReceiveResult result;
                        do
                        {
                            result = await _ws.ReceiveAsync(buffer, CancellationToken.None);
                            ms.Write(arrBuffer, buffer.Offset, result.Count);
                        } while (!result.EndOfMessage);


                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            _logger.LogInformation("closed");
                            continue;
                        }

                        ms.Seek(0, SeekOrigin.Begin);

                        using (var reader = new StreamReader(ms, Encoding.UTF8))
                        {
                            var text = await reader.ReadToEndAsync();

                            _logger.LogInformation($"message received {text}");

                            _lastMessageTime = DateTime.Now;

                            var message = GetMessage<Message>(text);

                            if (message.Type == MessageType.Ping)
                            {
                                await SendMessage(new Message
                                {
                                    Msg = message.Msg,
                                    Type = MessageType.Pong
                                });

                                continue;
                            }

                            if (_phase != ClientPhase.Ready)
                            {
                                await ProcessAuth(message);
                                continue;
                            }

                            ProcessDataMessage(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    await Task.Delay(1000);
                }
            }
        }

        private void ProcessDataMessage(Message message)
        {
            var header = GetMessage<Header>(message.Msg);

            if (!RequestTypes.Map.ContainsKey(header.RequestType))
            {
                _onMessage.OnNext(new NtProMessage
                {
                    RequestType = header.RequestType,
                    Payload = message.Msg
                });

                return;
            }

            var msg = GetMessage(RequestTypes.Map[header.RequestType], message.Msg);

            if (msg is CommandReplyPayload payload)
            {
                if (payload.Message.Result == CommandReply.ResultType.Error)
                    _logger.LogError($"Error received: {payload.Message.Message}");
            }

            _onMessage.OnNext(new NtProMessage
            {
                RequestType = header.RequestType,
                Payload = msg
            });
        }

        private async Task ProcessAuth(Message message)
        {
            if (_phase == ClientPhase.Auth)
            {
                var environment = GetMessage<EnvironmentReplyPayload>(message.Msg);

                _logger.LogInformation($"environment = {(Environment)environment.Message.Type}");

                if (environment.Message.Type != (int) _environment)
                    throw new Exception("Invalid Environment");

                _phase = ClientPhase.Login;
                 
                await SendDataMessage(new LoginRequestPayload
                {
                    Message = new LoginRequest
                    {
                        UserName = _userName,
                        Password = _password
                    }
                });

                return;
            }

            if (_phase == ClientPhase.Login)
            {
                var loginReply = GetMessage<LoginReplyPayload>(message.Msg);

                if (loginReply.Message.Reply.Result != CommandReply.ResultType.Success)
                    throw new Exception($"Login.Result != Success, {loginReply.Message.Reply.Message}");

                _phase = ClientPhase.SelectUserRole;
                 
                await SendDataMessage(new SelectUserRoleRequestPayload
                {
                    Message = new SelectUserRoleRequest()
                });

                return;
            }

            if (_phase == ClientPhase.SelectUserRole)
            {
                var commandReply = GetMessage<CommandReplyPayload>(message.Msg);
                if (commandReply.Message.Result != CommandReply.ResultType.Success)
                    throw new Exception($"SelectUserRole.Result != Success, {commandReply.Message}");

                _phase = ClientPhase.Ready;

                _logger.LogInformation("login succeed");

                if(_loginSemaphore.CurrentCount == 0)
                    _loginSemaphore.Release();

                _onConnected.OnNext(new object());

                return;
            }
        }

        private async Task CheckConnection()
        {
            while (true)
            {
                if (DateTime.Now - _lastMessageTime > new TimeSpan(0, 0, 0, _timeout))
                {
                    _logger.LogWarning($"last message arrived more than {_timeout} seconds ago, reconnecting");

                    await EnsureConnected();
                }

                await Task.Delay(1000);
            }
        }


        class Header
        {
            public string RequestType { get; set; }
        }

        private static TMessage GetMessage<TMessage>(string text)
        {
            var message = JsonConvert.DeserializeObject<TMessage>(text);
            return message;
        }

        private static object GetMessage(Type type, string text)
        {
            var message = JsonConvert.DeserializeObject(text, type);
            return message;
        }

        private async Task SendMessage(object message)
        {
            var json = JsonConvert.SerializeObject(message, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            _logger.LogInformation("SENT:\n{0}\n", json);

            await _ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(json)), WebSocketMessageType.Text, true,
                CancellationToken.None);
        }

        private async Task SendDataMessage<TPayload>(TPayload payload)
            where TPayload: PayloadBase
        {
            payload.OriginalRequestId = _messageId;
            payload.RequestId = _messageId;

            var dataMessage = GetDataMessage(payload);

            var json = JsonConvert.SerializeObject(dataMessage, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            _logger.LogInformation("SENT:\n{0}\n", json);

            _messageId++;

            await _ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(json)), WebSocketMessageType.Text, true,
                CancellationToken.None);
        }


        public async Task SubscribeQuoterGroups()
        {
            var msg = new SubscribeQuoterGroupsPayload
            {
                Message = new SubscribeQuoterGroups()
            };
            
            await SendOnExclusiveScheduler(msg);
        }

        public async Task SubscribePositionManagerSettings()
        {
            var msg = new SubscribePositionManagerSettingsPayload()
            {
                Message = new SubscribePositionManagerSettings()
            };

            await SendOnExclusiveScheduler(msg);
        }


        public async Task SubscribePositions(SubscribePositions subscribePositions)
        {
            var msg = new SubscribePositionsPayload
            {
                Message = subscribePositions
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task SubscribeQuoterSettings(SubscribeQuoterSettings subscribeQuoterSettings)
        {
            var msg = new SubscribeQuoterSettingsPayload
            {
                Message = subscribeQuoterSettings
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task SubscribeInstruments()
        {
            var msg = new SubscribeInstrumentsPayload
            {
                Message = new SubscribeInstruments()
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task SubscribeTags()
        {
            var msg = new SubscribeTagsPayload
            {
                Message = new SubscribeTags()
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task ChangeQuoterSettings(ChangeAction action, QuoterSetting quoterSetting)
        {
            var msg = new ChangeQuoterSettingsRequestPayload
            {
                Message = new ChangeQuoterSettingsRequest
                {
                    Action = action,
                    QuoterSetting = quoterSetting
                }
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task SubscribeOrderQuoterRules()
        {
            var msg = new SubscribeOrderQuoterRulesPayload
            {
                Message = new SubscribeOrderQuoterRules()
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task ChangeOrderQuoterRule(ChangeAction changeAction, OrderQuoterRule oqr)
        {
            var msg = new ChangeOrderQuoterRulesRequestPayload
            {
                Message = new ChangeOrderQuoterRulesRequest
                {
                    Action = changeAction,
                    OrderQuoterRule = oqr
                }
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task ChangePositionManagerSetting(ChangeAction changeAction, PositionManagerSetting pms)
        {
            var msg = new ChangePositionManagerSettingRequestPayload()
            {
                Message = new ChangePositionManagerSettingRequest
                {
                    Action = changeAction,
                    PositionManagerSettings = pms
                }
            };

            await SendOnExclusiveScheduler(msg);
        }

        public async Task SubscribeAssets()
        {
            var msg = new SubscribeAssetsPayload
            {
                Message = new SubscribeAssets()
            };

            await SendOnExclusiveScheduler(msg);
        }
    }
}