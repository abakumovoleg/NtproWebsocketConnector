namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class QuoterSettingsUpdatePayload : Payload<QuoterSettingsUpdate>
    {
        public QuoterSettingsUpdatePayload() : base(RequestTypes.QuoterSettingsUpdate)
        {
        }
    }
}