namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribeAssetsPayload : Payload<SubscribeAssets>
    {
        public SubscribeAssetsPayload() : base(RequestTypes.SubscribeAssets)
        {
        }
    }
}