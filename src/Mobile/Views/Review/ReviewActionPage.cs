namespace XClaim.Mobile.Views.Review;

public class ReviewActionPage : BaseView {
    public ReviewActionPage() => Build();

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
