namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribeQuoterSettingsPayload : Payload<SubscribeQuoterSettings>
    {
        public SubscribeQuoterSettingsPayload() : base(RequestTypes.SubscribeQuoterSettings)
        {
        }
    }
}