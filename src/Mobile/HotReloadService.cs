namespace XClaim.Mobile;
#if DEBUG
public static class HotReloadService {
#pragma warning disable CS8632
    public static event Action<Type[]?>? UpdateApplicationEvent;
#pragma warning restore CS8632

    internal static void ClearCache(Type[]? types) { }
    internal static void UpdateApplication(Type[]? types) {
        UpdateApplicationEvent?.Invoke(types);
    }
}
#endif
