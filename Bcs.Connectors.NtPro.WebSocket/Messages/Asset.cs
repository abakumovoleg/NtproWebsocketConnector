namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class Asset
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double AmountStep { get; set; }
        public int Type { get; set; }
    }
}