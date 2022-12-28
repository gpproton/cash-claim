namespace XClaim.Mobile.Views.Review;

public class ReviewHistoryView : BaseView {
    public ReviewHistoryView() {
        Build();
    }

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
                new Label {
                    Text = "Claim history view!"
                }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}