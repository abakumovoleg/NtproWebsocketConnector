namespace Bcs.Connectors.NtPro.WebSocket
{
    enum ClientPhase
    {
        None,
        Auth,
        Login,
        SelectUserRole,
        Ready
    }
}