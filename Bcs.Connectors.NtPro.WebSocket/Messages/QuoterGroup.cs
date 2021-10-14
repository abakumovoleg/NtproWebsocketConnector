namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class QuoterGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OwnerFirmId { get; set; }
        public int LocationId { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, OwnerFirmId = {OwnerFirmId}, LocationId = {LocationId}, Comment = {Comment}";
        }
    }
}