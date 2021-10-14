namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class LoginReply
    {
        public CommandReply Reply { get; set; }
        public int[] AvailableRoles { get; set; } = new int[0];
        public int DefaultRole { get; set; }
    }
}