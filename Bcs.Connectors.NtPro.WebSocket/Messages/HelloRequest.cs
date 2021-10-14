namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class HelloRequest
    {

        public int VersionMajor { get; set; } = 3;
        public int VersionMinor { get; set; } = 12;
    }
}