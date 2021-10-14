namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SubscribeTagsPayload : Payload<SubscribeTags>
    {
        public SubscribeTagsPayload() : base(RequestTypes.SubscribeTags)
        {
            
        }
    }
}