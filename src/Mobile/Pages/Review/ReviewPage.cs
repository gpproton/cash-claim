namespace XClaim.Mobile.Pages.Review;

public class ReviewPage : BasePage<ReviewViewModel>
{
    public ReviewPage(ReviewViewModel vm) : base(vm) => Build();

    void Build()
    {
        Title = "Claim reviews";
        ToolbarItems.Add(new ToolbarItem { IconImageSource = new FontImageSource {
            FontFamily = "FASolid",
            Glyph = FA.Solid.Sliders
        }.DynamicResource(FontImageSource.ColorProperty, "Primary")});
        Content = new VerticalStackLayout {
            Children = {
                new Label { Text = "Claim pending view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}

public class ReviewViewModel : BaseViewModel { }