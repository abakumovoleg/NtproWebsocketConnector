namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class PositionManagerGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OwnerFirmId { get; set; }
        public long PortfolioId { get; set; }
        public long CoverLoginId { get; set; }
    }
}