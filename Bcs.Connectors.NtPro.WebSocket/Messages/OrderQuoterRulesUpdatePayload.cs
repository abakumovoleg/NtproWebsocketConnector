namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class OrderQuoterRulesUpdatePayload : Payload<OrderQuoterRulesUpdate>
    {
        public OrderQuoterRulesUpdatePayload() : base(RequestTypes.OrderQuoterRulesUpdate)
        {
        }
    }
}