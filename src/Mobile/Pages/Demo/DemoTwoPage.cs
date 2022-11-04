using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Demo;

public class DemoTwoPage : BasePage {
    public DemoTwoPage() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label().Text("Demo two view!").CenterHorizontal().CenterVertical()
        }
        };
    }
}

internal partial class DemoTwoViewModel : BaseViewModel { }
