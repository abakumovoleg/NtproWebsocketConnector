using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Bcs.Connectors.NtPro.WebSocket.Messages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Environment = Bcs.Connectors.NtPro.WebSocket.Messages.Environment;

namespace Bcs.Connectors.NtPro.WebSocket.Console
{
     
    class Program
    {
     
        static async Task Main(string[] args)
        { 
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("SampleApp.Program", LogLevel.Debug)
                        .AddConsole();
                }
            );

            var client = new Client(Environment.UAT, "wss://public-api-uat.ntprog.com", "websocket@BCSFX", "pq61gDDo", loggerFactory.CreateLogger<Client>());
            
            client.Connect();

            await client.WaitLogin();

            client.OnMessage.Where(x => x.RequestType == RequestTypes.TagsUpdate)
                .Subscribe(x =>
                {
                    System.Console.WriteLine((TagsUpdatePayload) x.Payload);
                });

            await client.SubscribeTags();
            /*
            client.OnMessage.Where(x => x.RequestType == RequestTypes.QuoterGroupsUpdate)
                .Subscribe(async x =>
                {
                    var payload = (QuoterGroupsUpdatePayload) x.Payload;

                    foreach (var quoterGroup in payload.Message.QuoterGroups)
                    {
                        await client.SubscribeQuoterSettings(new SubscribeQuoterSettings
                        {
                            OwnerFirmId = quoterGroup.OwnerFirmId,
                            QuoterGroupId = quoterGroup.Id
                        });
                    }
                });

            var quoterSettings = new HashSet<QuoterSetting>();

            var sub = client.OnMessage.Where(x => x.RequestType == RequestTypes.QuoterSettingsUpdate)
                .Subscribe(x =>
                {
                    var payload = (QuoterSettingsUpdatePayload) x.Payload;
                    foreach (var data  in payload.Message.Data)
                    {
                        quoterSettings.Remove(data);
                        quoterSettings.Add(data);
                    }
                });
            
            await client.SubscribeQuoterGroups();

            System.Console.ReadLine();

            sub.Dispose();

            var tasks = new List<Task>();
            foreach (var quoterSetting in quoterSettings)
            {
                quoterSetting.BidShift = 0.01;
                tasks.Add(client.ChangeQuoterSettings(ChangeAction.Change, quoterSetting));
            }

            await Task.WhenAll(tasks);
            */

            System.Console.ReadLine();
        }
    }
}
