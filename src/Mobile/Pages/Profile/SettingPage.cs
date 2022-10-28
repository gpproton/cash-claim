namespace XClaim.Mobile.Pages.Profile;

public class SettingPage : BasePage {
    public SettingPage() => Content = new VerticalStackLayout {
        Children = {
            new Label {
                Text = "Settings view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
    };
}
