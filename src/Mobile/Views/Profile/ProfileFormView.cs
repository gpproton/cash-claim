namespace XClaim.Mobile.Views.Profile;

public class ProfileFormView : BaseView {
    public ProfileFormView() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label {
                Text = "Profile form view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
        };
    }
}
