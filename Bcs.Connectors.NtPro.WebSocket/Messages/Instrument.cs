namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class Instrument
    {
        public long InstrumentBasisId { get; set; }
        public string Name { get; set; }
        public string BaseAsset { get; set; }
    }
}