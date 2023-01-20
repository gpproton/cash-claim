using Microsoft.AspNetCore.Components;

namespace XClaim.Web.Shared.States;

public class AppState : RootState {
    public RenderFragment? LayoutTitle { get; private set; } = default!;
    
    public bool IsSidebarOpen { get; private set; } = true;

    public void SetLayoutTitle(RenderFragment? value) {
        LayoutTitle = value;
        NotifyStateChanged();
    }

    public void ToggleSidebar() {
        IsSidebarOpen = !IsSidebarOpen;
        NotifyStateChanged();
    }
}