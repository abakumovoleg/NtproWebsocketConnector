namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class QuoterGroupsUpdatePayload : Payload<QuoterGroupsUpdate>
    {
        public QuoterGroupsUpdatePayload() : base(RequestTypes.QuoterGroupsUpdate)
        {
        }
    }
}