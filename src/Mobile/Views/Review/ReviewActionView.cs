namespace XClaim.Mobile.Views.Review;

public class ReviewActionView : BaseView {
    public ReviewActionView() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label {
                Text = "Claim review view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
        };
    }
}
