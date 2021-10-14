namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class ChangeQuoterSettingsRequest
    {
        public QuoterSetting QuoterSetting { get; set; }
        public ChangeAction Action { get; set; }
    }
}