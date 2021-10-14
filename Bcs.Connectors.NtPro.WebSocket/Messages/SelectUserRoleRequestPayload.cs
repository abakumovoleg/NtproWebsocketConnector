namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class SelectUserRoleRequestPayload : Payload<SelectUserRoleRequest>
    {
        public SelectUserRoleRequestPayload() : base(RequestTypes.SelectUserRoleRequest)
        {
        }
    }
}