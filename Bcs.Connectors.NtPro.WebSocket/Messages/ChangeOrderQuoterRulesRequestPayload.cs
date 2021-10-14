namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class ChangeOrderQuoterRulesRequestPayload : Payload<ChangeOrderQuoterRulesRequest>
    {
        public ChangeOrderQuoterRulesRequestPayload() : base(RequestTypes.ChangeOrderQuoterRulesRequest)
        {
        }
    }
}