namespace XClaim.Mobile.Views.Profile;

public class SettingView : BaseView<SettingViewModel> {
    public SettingView(SettingViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Account Setting";
        Content = new VerticalStackLayout {
            Children = {
                new Label {
                    Text = "Setting!"
                }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}

public partial class SettingViewModel : BaseViewModel { }