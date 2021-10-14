namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class InstrumentsUpdate
    {
        public Instrument[] Instruments { get; set; }
        public bool IsNextDataPending { get; set; }

    }
}