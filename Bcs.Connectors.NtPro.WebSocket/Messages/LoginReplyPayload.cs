namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class LoginReplyPayload : Payload<LoginReply>
    {
        public LoginReplyPayload() : base("LoginReply")
        {
        }
    }
}