using Microsoft.AspNetCore.Components;
using XClaim.Common;
using XClaim.Common.Dtos;

namespace XClaim.Web.Shared.States;

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

    public async Task LoadServerState(ServerStateResponse server) {
        ServerState = server;
        AppTitle = server.ServiceName;
        NotifyStateChanged();
    }
}