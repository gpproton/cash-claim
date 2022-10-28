namespace XClaim.Mobile.Pages.Profile;

public class PasswordPage : BasePage {
    public PasswordPage() => Content = new VerticalStackLayout {
        Children = {
            new Label {
                Text = "Password reset view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
    };
}
