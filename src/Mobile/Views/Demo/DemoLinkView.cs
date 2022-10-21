using XClaim.Mobile.ViewModel;
using XClaim.Mobile.Views.Demo;

namespace XClaim.Mobile.Views;

internal class DemoLinkView : BaseView<DemoLinkViewModel>
{
    public DemoLinkView(DemoLinkViewModel demoLinkViewModel) : base(demoLinkViewModel) {
        Content = new VerticalStackLayout {
            Children = {
            new Label()
            .Text("Home view!")
            .TextCenterHorizontal()
            .TextCenterVertical(),
            new Button {BackgroundColor = Colors.DodgerBlue }
            .Text("Demo One")
            .Margins(8,8,8,8)
            .BindCommand(nameof(DemoLinkViewModel.NavigateToDemoOneCommand)),
            new Button {BackgroundColor = Colors.DarkOrchid }
            .Text("Demo Two")
            .Margins(8,8,8,8)
            .BindCommand(nameof(DemoLinkViewModel.NavigateToDemoTwoCommand))
        }
        };
        Shell.SetNavBarIsVisible(Content, false);
    }
}

internal partial class DemoLinkViewModel : BaseViewModel
{
    [RelayCommand]
    public async void NavigateToDemoOne() => await Shell.Current.GoToAsync(nameof(DemoOneView));

    [RelayCommand]
    public async void NavigateToDemoTwo() => await Shell.Current.GoToAsync(nameof(DemoTwoView));
}
