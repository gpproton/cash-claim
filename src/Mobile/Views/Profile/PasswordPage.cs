namespace XClaim.Mobile.Views.Profile;

public class PasswordPage : BaseView {
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
