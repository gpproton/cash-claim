namespace XClaim.Mobile.Pages.Profile;

public class PasswordPage : BasePage {
    public PasswordPage() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label {
                Text = "Password reset view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
        };
    }
}
