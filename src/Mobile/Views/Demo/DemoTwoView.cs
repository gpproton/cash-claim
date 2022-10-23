using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views.Demo;

public class DemoTwoView : ContentPage
{
    public DemoTwoView() => Content = new VerticalStackLayout
    {
        Children = {
                new Label().Text("Demo two view!").CenterHorizontal().CenterVertical(),
                
                new FormView {
                Spacing = 20,
                Children = { }
            }
        }
    };
}

internal partial class DemoTwoViewModel : BaseViewModel { }
