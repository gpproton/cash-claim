namespace XClaim.Mobile.Pages.Profile;

public class SettingPage : BasePage {
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
