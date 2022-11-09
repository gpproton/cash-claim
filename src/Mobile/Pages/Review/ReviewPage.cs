namespace XClaim.Mobile.Pages.Review;

public class ReviewPage : BasePage<ReviewViewModel> {
    public ReviewPage(ReviewViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Build();
    }

    protected override void Build() {
        Title = "Claim Reviews";
        Content = new EmptyItemView().Margins(0, 56);
    }
}

public class ReviewViewModel : BaseViewModel { }
