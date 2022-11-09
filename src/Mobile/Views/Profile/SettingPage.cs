namespace XClaim.Mobile.Views.Profile;

public class SettingPage : BaseView {
    public SettingPage() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label {
                Text = "Settings view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
        };
    }
}
