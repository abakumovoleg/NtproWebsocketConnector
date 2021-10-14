namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class PayloadBase
    {
        public long RequestId { get; set; }
        public long OriginalRequestId { get; set; }
        public string RequestType { get; set; }
    }
}