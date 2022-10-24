using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages;

public class BasePage : ContentPage
{
    protected BasePage(in bool shouldUseSafeArea = false) {
        On<iOS>().SetUseSafeArea(shouldUseSafeArea);
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
    }
}

public abstract class BasePage<T> : BasePage where T : BaseViewModel {
    protected BasePage(in T viewModel, in bool shouldUseSafeArea = false) : base(shouldUseSafeArea) {
        base.BindingContext = viewModel;
    }

    protected new T BindingContext => (T)base.BindingContext;
}
