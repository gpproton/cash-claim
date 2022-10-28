using Microsoft.Maui.Controls.Shapes;

namespace XClaim.Mobile.Views;

public enum SwitcherButton { }

public class SwitcherButtonView : Border {
    public SwitcherButtonView() {
        Padding = 1;
        StrokeThickness = 0F;
        StrokeShape = new RoundRectangle {
            CornerRadius = new CornerRadius(5)
        };
        SetDynamicResource(BackgroundProperty, "Tertiary");
        Content = new StackLayout {
            Orientation = StackOrientation.Horizontal,
            Children = { }
        };
    }
}
