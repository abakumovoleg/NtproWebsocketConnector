namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class InstrumentsUpdatePayload :Payload<InstrumentsUpdate>
    {
        public InstrumentsUpdatePayload(string requestType) : base(requestType)
        {
        }
    }
}