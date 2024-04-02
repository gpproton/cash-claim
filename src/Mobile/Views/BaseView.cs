using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using UraniumUI.Pages;

namespace XClaim.Mobile.Views;

public abstract class BaseView : UraniumContentPage {
    protected BaseView(in bool shouldUseSafeArea = false) {
        On<iOS>().SetUseSafeArea(shouldUseSafeArea);
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
    }

    protected abstract void Build();

    protected override void OnNavigatedTo(NavigatedToEventArgs args) {
        base.OnNavigatedTo(args);
        Build();
#if DEBUG
        HotReloadService.UpdateApplicationEvent += ReloadUI;
#endif
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args) {
        base.OnNavigatedFrom(args);
#if DEBUG
        HotReloadService.UpdateApplicationEvent -= ReloadUI;
#endif
    }

    private void ReloadUI(Type[] obj) {
        MainThread.BeginInvokeOnMainThread(Build);
    }
}

public abstract class BaseView<T> : BaseView where T : BaseViewModel {
    protected BaseView(in T viewModel, in bool shouldUseSafeArea = false) : base(shouldUseSafeArea) {
        base.BindingContext = viewModel;
    }

    protected new T BindingContext => (T)base.BindingContext;
}

public abstract partial class BaseViewModel : ObservableObject {
    [ObservableProperty] private bool _isBusy;

    [ObservableProperty] private string _title;
}

public abstract partial class ListViewModel : BaseViewModel {
    [ObservableProperty] protected bool _isRefreshing;

    [ObservableProperty] protected bool _isLoading;

    [RelayCommand]
    protected async Task RefreshItems() {
        if (!IsRefreshing) IsRefreshing = true;
        await Task.Delay(500);
        IsRefreshing = false;
    }
}