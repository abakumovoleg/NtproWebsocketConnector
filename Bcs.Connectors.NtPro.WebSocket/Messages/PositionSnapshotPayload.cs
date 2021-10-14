namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class PositionSnapshotPayload : Payload<PositionSnapshot>
    {
        public PositionSnapshotPayload() : base(RequestTypes.PositionSnapshot)
        {
        }
    }
}