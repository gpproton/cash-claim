using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Demo;

public class DemoTwoPage : BasePage {
    public DemoTwoPage() => Content = new VerticalStackLayout {
        Children = {
            new Label().Text("Demo two view!").CenterHorizontal().CenterVertical()
        }
    };
}

internal partial class DemoTwoViewModel : BaseViewModel { }
