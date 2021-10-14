namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class ChangeQuoterSettingsRequestPayload : Payload<ChangeQuoterSettingsRequest>
    {
        public ChangeQuoterSettingsRequestPayload() : base(RequestTypes.ChangeQuoterSettingsRequest)
        {
        }
    }
}