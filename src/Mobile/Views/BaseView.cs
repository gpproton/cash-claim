using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.PlatformConfiguration;
using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

internal class BaseView : ContentPage {
    protected BaseView(in bool shouldUseSafeArea = false) {
        On<iOS>().SetUseSafeArea(shouldUseSafeArea);
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
    }
}

internal abstract class BaseView<T> : BaseView where T : BaseViewModel {
    protected BaseView(in T viewModel, in bool shouldUseSafeArea = false) : base(shouldUseSafeArea) {
        base.BindingContext = viewModel;
    }

    protected new T BindingContext => (T)base.BindingContext;
}
