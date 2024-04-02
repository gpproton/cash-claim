using Microsoft.AspNetCore.Components;
using CashClaim.Common;
using CashClaim.Common.Dtos;

namespace CashClaim.Web.Shared.States;

public class AppState : RootState {
    public RenderFragment? LayoutTitle { get; private set; }

    public string? AppTitle { get; private set; } = SharedConst.ServiceName;
    
    public ServerStateResponse? ServerState { get; private set; }

    public bool IsSidebarOpen { get; private set; } = true;

    public void SetLayoutTitle(RenderFragment? value) {
        LayoutTitle = value;
        NotifyStateChanged();
    }
    
    public void SetAppTitle(string? value) {
        AppTitle = value;
        NotifyStateChanged();
    }

    public void ToggleSidebar() {
        IsSidebarOpen = !IsSidebarOpen;
        NotifyStateChanged();
    }

    public void LoadServerState(ServerStateResponse server) {
        ServerState = server;
        AppTitle = server.ServiceName;
        NotifyStateChanged();
    }
}