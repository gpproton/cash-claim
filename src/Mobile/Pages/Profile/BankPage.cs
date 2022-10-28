namespace XClaim.Mobile.Pages.Profile;

public class BankPage : BasePage {
    public BankPage() => Content = new VerticalStackLayout {
        Children = {
            new Label {
                Text = "Bank view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
    };
}
