namespace XClaim.Mobile.Pages.Profile;

public class BankFormPage : BasePage {
    public BankFormPage() => Content = new VerticalStackLayout {
        Children = {
            new Label {
                Text = "Bank form view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
    };
}
