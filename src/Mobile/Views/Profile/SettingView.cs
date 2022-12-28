namespace XClaim.Mobile.Views.Profile;

public class SettingView : BaseView {
    public SettingView() {
        Build();
    }

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