namespace XClaim.Web.Components.States;

public abstract class RootState {
    public event Action? OnChange;

    protected void NotifyStateChanged() => OnChange?.Invoke();
}