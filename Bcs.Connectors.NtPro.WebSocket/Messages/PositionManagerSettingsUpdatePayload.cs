namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class PositionManagerSettingsUpdatePayload : Payload<PositionManagerSettingsUpdate>
    {
        public PositionManagerSettingsUpdatePayload() : base(RequestTypes.PositionManagerSettingsUpdate)
        {
        }
    }
}