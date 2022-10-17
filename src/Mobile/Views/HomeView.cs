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
            .Text("Demo One")
            .Margins(8,8,8,8)
            .BindCommand(nameof(HomeViewModel.NavigateToDemoOneCommand)),
            new Button {BackgroundColor = Colors.DarkOrchid }
            .Text("Demo Two")
            .Margins(8,8,8,8)
            .BindCommand(nameof(HomeViewModel.NavigateToDemoTwoCommand)),
         }
    };
}

internal partial class HomeViewModel : BaseViewModel
{
    [RelayCommand]
    public async void NavigateToDemoOne() => await Shell.Current.GoToAsync(nameof(DemoOneView));

    [RelayCommand]
    public async void NavigateToDemoTwo() => await Shell.Current.GoToAsync(nameof(DemoTwoView));
}
