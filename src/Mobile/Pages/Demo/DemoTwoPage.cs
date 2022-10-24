using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Demo;

public class DemoTwoPage : ContentPage
{
    public DemoTwoPage() => Content = new VerticalStackLayout
    {
        Children = {
                new Label().Text("Demo two view!").CenterHorizontal().CenterVertical()
        }
    };
}

internal partial class DemoTwoViewModel : BaseViewModel { }
