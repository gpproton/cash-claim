using Microsoft.Maui.Controls.Shapes;

namespace XClaim.Mobile.Views;

public enum SegmentButton { }

public class SegmentView : Border {
    readonly string[] items = { "Pending", "Confirmed", "Completed" };

    class SegmentButton : Button {
        public SegmentButton() {
            this.HorizontalOptions = LayoutOptions.Center;
            this.Margins(0, 0, 8, 0);
            this.DynamicResource(BackgroundColorProperty, "Primary");
        }
    }

    public SegmentView() {
        Padding = 3;
        Margin = 8;
        StrokeShape = new RoundRectangle {
            CornerRadius = new CornerRadius(10)
        };
        SetDynamicResource(BackgroundColorProperty, "Tertiary");
        var segButton = new SegmentButton();
        var layout = new HorizontalStackLayout()
            .ItemsSource(items)
            .ItemTemplate(new DataTemplate(() => new RadioButton {
                ControlTemplate = new ControlTemplate(() => segButton.Bind(Button.TextProperty, "Content", source: RelativeBindingSource.TemplatedParent)
                    )
                }.Bind(RadioButton.ContentProperty)
            ));
        RadioButtonGroup.SetGroupName(layout, "MenuGroup");
        var vsGroups = new VisualStateGroup() {
            Name = "CheckedStates",
        };
        vsGroups.States.Add(new VisualState {
            Name = "Checked",
            Setters = {
                new Setter { TargetName = nameof(SegmentButton), Property = Button.BackgroundColorProperty, Value = Colors.Indigo }
            }
        });
        vsGroups.States.Add(new VisualState {
            Name = "Unchecked",
            Setters = {
                new Setter { TargetName = nameof(SegmentButton), Property = Button.BackgroundColorProperty, Value = Colors.Transparent },
                new Setter { TargetName = nameof(SegmentButton), Property = Button.TextColorProperty, Value = Colors.Indigo }
            }
        });
        VisualStateManager.SetVisualStateGroups(layout,
                new VisualStateGroupList {
                    
                }
            );
        Content = layout;
    }
}
