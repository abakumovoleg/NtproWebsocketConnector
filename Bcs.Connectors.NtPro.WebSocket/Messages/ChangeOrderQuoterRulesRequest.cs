namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class ChangeOrderQuoterRulesRequest
    {
        public ChangeAction Action { get; set; }
        public OrderQuoterRule OrderQuoterRule { get; set; }
    }
}