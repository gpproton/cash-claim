using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

internal class HomeView : BaseView<HomeViewModel>
{
    public HomeView(HomeViewModel homeViewModel) : base(homeViewModel) => Content = new VerticalStackLayout
    {
        Children = {
            new Label()
            .Text("Home view!")
            .TextCenterHorizontal()
            .TextCenterVertical(),
            new Button {BackgroundColor = Colors.DodgerBlue }
            .Text("Goto Demo")
            .Margins(8,16,8,16)
            .BindCommand(nameof(HomeViewModel.NavigateToDemoCommand))
         }
    };
}

internal partial class HomeViewModel : BaseViewModel
{
    [RelayCommand]
    public async void NavigateToDemo() => await Shell.Current.GoToAsync(nameof(DemoView));
}
