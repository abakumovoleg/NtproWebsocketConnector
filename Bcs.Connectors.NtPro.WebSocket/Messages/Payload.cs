namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class Payload<TMessage> : PayloadBase
    {
        public Payload(string requestType)
        {
            RequestType = requestType;
        }
    
        public TMessage Message { get; set; }
    }
}