namespace Bcs.Connectors.NtPro.WebSocket
{
    public class NtProMessage
    {
        public string RequestType { get; set; }
        public object Payload { get; set; }
    }
}