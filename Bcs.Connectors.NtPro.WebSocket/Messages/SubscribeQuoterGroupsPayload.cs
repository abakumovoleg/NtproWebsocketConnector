namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribeQuoterGroupsPayload : Payload<SubscribeQuoterGroups>
    {
        public SubscribeQuoterGroupsPayload() : base(RequestTypes.SubscribeQuoterGroups)
        {
        }
    }
}