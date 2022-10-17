using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

public class DemoTwoView : ContentPage {
    public DemoTwoView() => Content = new VerticalStackLayout
    {
        Children = {
                new Label().Text("Demo two view!").CenterHorizontal().CenterVertical()
         }
    };
}

internal partial class DemoTwoViewModel : BaseViewModel { }
