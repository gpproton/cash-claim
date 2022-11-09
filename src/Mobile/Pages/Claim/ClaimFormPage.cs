using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Claim;

public class ClaimFormPage : BaseView<ClaimFormViewModel> {
    public ClaimFormPage(ClaimFormViewModel vm) : base(vm) => Build();

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
