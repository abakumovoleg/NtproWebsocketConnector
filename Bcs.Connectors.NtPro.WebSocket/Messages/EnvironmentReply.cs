namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class EnvironmentReply
    {
        public int Type { get; set; }
        public int VersionMajor { get; set; }
        public int VersionMinor { get; set; }
    }
}