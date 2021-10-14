namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribeInstrumentsPayload : Payload<SubscribeInstruments>
    {
        public SubscribeInstrumentsPayload() : base(RequestTypes.SubscribeInstruments)
        {
        }
    }
}