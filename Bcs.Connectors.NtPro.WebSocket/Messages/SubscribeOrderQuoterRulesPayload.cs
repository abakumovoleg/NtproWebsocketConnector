namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribeOrderQuoterRulesPayload : Payload<SubscribeOrderQuoterRules>
    {
        public SubscribeOrderQuoterRulesPayload() : base(RequestTypes.SubscribeOrderQuoterRules)
        {
        }
    }
}