namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class CommandReply
    {
        public enum ResultType
        {
            Success = 0,
            Error = 1
        }
        public ResultType Result { get; set; }
        public string Message { get; set; }
    }
}