namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribePositionsPayload : Payload<SubscribePositions>
    {
        public SubscribePositionsPayload() : base(RequestTypes.SubscribePositions)
        {
        }
    }
}