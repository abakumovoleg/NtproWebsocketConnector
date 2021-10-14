namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class OrderQuoterRulesUpdate
    {
        public OrderQuoterRule[] Data { get; set; }
        public bool IsNextDataPending { get; set; }
        public long[] DeletedIds { get; set; }
    }
}