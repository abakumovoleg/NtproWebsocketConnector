namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class ChangePositionManagerSettingRequest
    {
        public ChangeAction Action { get; set; }
        public PositionManagerSetting PositionManagerSettings { get; set; }
    }
}