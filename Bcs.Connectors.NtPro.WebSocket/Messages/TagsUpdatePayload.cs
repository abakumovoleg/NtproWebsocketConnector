namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class TagsUpdatePayload : Payload<TagsUpdate>
    {
        public TagsUpdatePayload() : base(RequestTypes.TagsUpdate)
        {
        }
    }
}