namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class CommandReplyPayload : Payload<CommandReply>
    {
        public CommandReplyPayload() : base(RequestTypes.CommandReply)
        {
        }
    }
}