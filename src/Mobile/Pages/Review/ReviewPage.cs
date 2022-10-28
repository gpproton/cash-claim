using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Review;

public class ReviewPage : BasePage<ReviewViewModel>
{
    public ReviewPage(ReviewViewModel vm) : base(vm) => Build();

    void Build()
    {
        Title = "Claim Reviews";
        ToolbarItems.Add(new ToolbarItem { IconImageSource = new FontImageSource {
            FontFamily = "FASolid",
            Glyph = FA.Solid.Sliders
        }.DynamicResource(FontImageSource.ColorProperty, "Primary")});

        Content = new EmptyItemView().Margins(0, 56);
    }
}

public class ReviewViewModel : BaseViewModel { }