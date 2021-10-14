namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class HelloRequestPayload : Payload<HelloRequest>
    {
        public HelloRequestPayload() : base(RequestTypes.Hello)
        {
        }
    }
}