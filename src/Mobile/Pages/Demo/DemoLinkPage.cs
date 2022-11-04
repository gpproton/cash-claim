using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Demo;

internal class DemoLinkPage : BasePage<DemoLinkViewModel> {
    public DemoLinkPage(DemoLinkViewModel vm) : base(vm) => Build();

    //Shell.SetNavBarIsVisible(Content, false);

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label()
            .Text("Home view!")
            .TextCenterHorizontal()
            .TextCenterVertical(),
            new Button {
                BackgroundColor = Colors.DodgerBlue
            }
            .Text("Demo One")
            .Margins(8, 8, 8, 8)
            .BindCommand(nameof(DemoLinkViewModel.NavigateToDemoOneCommand)),
            new Button {
                BackgroundColor = Colors.DarkOrchid
            }
            .Text("Demo Two")
            .Margins(8, 8, 8, 8)
            .BindCommand(nameof(DemoLinkViewModel.NavigateToDemoTwoCommand))
        }
        };
    }
}

internal partial class DemoLinkViewModel : BaseViewModel {
    [RelayCommand]
    private async void NavigateToDemoOne() => await Shell.Current.GoToAsync(nameof(DemoOnePage));

    [RelayCommand]
    private async void NavigateToDemoTwo() => await Shell.Current.GoToAsync(nameof(DemoTwoPage));
}
