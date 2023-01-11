using Microsoft.AspNetCore.Components;

namespace XClaim.Web.Shared;

public class AppState {
    public RenderFragment? LayoutTitle { get; set; }
    public bool ShowFooter { get; set; }
    public event Action? StateChanged;

    public void SetLayoutTitle(RenderFragment? value) {
        LayoutTitle = value;
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged() => StateChanged?.Invoke();
}