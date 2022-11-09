namespace XClaim.Mobile.Pages.Startup;

public class ConfigPage : BaseView<ConfigViewModel> {
    public ConfigPage(ConfigViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = { }
        };
    }
}

public partial class ConfigViewModel : BaseViewModel { }