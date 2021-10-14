namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribePositionManagerSettingsPayload : Payload<SubscribePositionManagerSettings>
    {
        public SubscribePositionManagerSettingsPayload() : base(RequestTypes.SubscribePositionManagerSettings)
        {
        }
    }
}