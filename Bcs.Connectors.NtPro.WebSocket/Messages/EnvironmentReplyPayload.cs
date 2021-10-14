namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class EnvironmentReplyPayload : Payload<EnvironmentReply>
    {
        public EnvironmentReplyPayload() : base( RequestTypes.Environment)
        {
        }
    }
}