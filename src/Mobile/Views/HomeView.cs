using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

internal class HomeView : BaseView<HomeViewModel>
{
    public HomeView(HomeViewModel homeViewModel) : base(homeViewModel) {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label().Text("Home sample...")
            }
        };
        Shell.SetNavBarIsVisible(Content, true);
    }
}

internal partial class HomeViewModel : BaseViewModel { }
