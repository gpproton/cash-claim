namespace XClaim.Mobile.Views.Profile;

public class BankView : BaseView<BankViewModel> {
    public BankView(BankViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Bank Account";
        Content = new VerticalStackLayout {
            Children = {
                new Label().Text("Bank view").CenterHorizontal()
            }
        };
    }
}

public partial class BankViewModel : BaseViewModel { }