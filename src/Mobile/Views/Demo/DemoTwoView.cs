using InputKit.Shared.Controls;
using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views.Demo;

public class DemoTwoView : UraniumContentPage
{
    public DemoTwoView() => Content = new VerticalStackLayout
    {
        Children = {
                new Label().Text("Demo two view!").CenterHorizontal().CenterVertical(),
                new TextField { Title = "Sample TextField",
                Icon =  new FontImageSource() {
                        FontFamily = "FASolid", Glyph = FA.Solid.User,
                        Color = Colors.Indigo, Size = 16
                    }
                },
                new FormView {
                Spacing = 20,
                Children = {
                    new TimePickerField {
                        Title = "Time Picker",
                        Icon = new FontImageSource() { FontFamily = "FASolid", Glyph = FA.Solid.Clock }
                    }
                }
            }
        }
    };
}

internal partial class DemoTwoViewModel : BaseViewModel { }
