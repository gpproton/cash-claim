namespace CashClaim.Web.Shared.States;

public abstract class RootState {
    public event Action? OnChange;

    protected void NotifyStateChanged() => OnChange?.Invoke();
}