namespace CashClaim.Mobile.Views.Startup;

public class ConfigView : BaseView<ConfigViewModel> {
    public ConfigView(ConfigViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = { }
        };
    }
}

public partial class ConfigViewModel : BaseViewModel { }