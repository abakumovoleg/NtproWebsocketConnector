namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OwnerFirmId { get; set; }
        public bool IsActive { get; set; }
        public string Comment { get; set; }
    }
}