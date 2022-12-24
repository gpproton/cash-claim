namespace XClaim.Mobile.Views.Startup;

public class VerifyAccountView : BaseView<VerifyAccountViewModel> {

    public VerifyAccountView(VerifyAccountViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new VerticalStackLayout() { };
    }
}

public partial class VerifyAccountViewModel : BaseViewModel { }
