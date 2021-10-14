namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class ChangePositionManagerSettingRequestPayload : Payload<ChangePositionManagerSettingRequest>
    {
        public ChangePositionManagerSettingRequestPayload() : base(RequestTypes.ChangePositionManagerSettingRequest)
        {
        }
    }
}