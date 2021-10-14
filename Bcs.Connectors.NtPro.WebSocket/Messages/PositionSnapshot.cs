namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class PositionSnapshot
    {
        public long? AccountId { get; set; }
        public long? PortfolioId { get; set; }
        public long? FirmId { get; set; }
        public JsonPositionSnapshot SpotQuotum { get; set; }
        public JsonPositionSnapshot ForwardQuotum { get; set; }
        public string AccountCurrency { get; set; }
        public JsonMarginParameters MarginParameters { get; set; }
    }
}