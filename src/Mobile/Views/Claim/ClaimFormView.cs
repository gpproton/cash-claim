namespace XClaim.Mobile.Views.Claim;

public class ClaimFormView : BaseView<ClaimFormViewModel> {
    public ClaimFormView(ClaimFormViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Create Request";
        Content = new VerticalStackLayout {
            Children = {
                new Label {
                    Text = "Claim form view!"
                }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}

public class ClaimFormViewModel : BaseViewModel { }
