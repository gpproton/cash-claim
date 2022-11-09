namespace XClaim.Mobile.Views.Profile;

public class ProfileFormPage : BaseView {
    public ProfileFormPage() => Build();

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
