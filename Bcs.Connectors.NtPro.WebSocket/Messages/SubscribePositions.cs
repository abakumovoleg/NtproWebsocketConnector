namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribePositions
    {
        public long? AccountId { get; set; }
        public long? PortfolioId { get; set; }
        public long? FirmId { get; set; }
    }
}