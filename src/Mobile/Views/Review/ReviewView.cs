namespace XClaim.Mobile.Views.Review;

public class ReviewView : BaseView<ReviewViewModel> {
    public ReviewView(ReviewViewModel vm) : base(vm) {
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
