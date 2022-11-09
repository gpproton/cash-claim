namespace XClaim.Mobile.Views.Profile;

public class PasswordView : BaseView {
    public PasswordView() => Build();

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
