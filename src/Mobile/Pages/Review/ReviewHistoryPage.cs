namespace XClaim.Mobile.Pages.Review;

public class ReviewHistoryPage : BasePage {
    public ReviewHistoryPage() => Content = new VerticalStackLayout {
        Children = {
            new Label {
                Text = "Claim history view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
    };
}
