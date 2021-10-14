namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class LoginRequestPayload : Payload<LoginRequest>
    {
        public LoginRequestPayload() : base(RequestTypes.LoginRequest)
        {
        }
    }
}