namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class AssetsUpdatePayload : Payload<AssetsUpdate>
    {
        public AssetsUpdatePayload(string requestType) : base(RequestTypes.AssetsUpdate)
        {
        }
    }
}