using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Claim;

public class ClaimFormPage : BasePage<ClaimFormViewModel>
{
	public ClaimFormPage(ClaimFormViewModel claimFormVm) : base(claimFormVm) => Build();

	void Build() {
        Title = "Create Request";
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { Text = "Claim form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}

public class ClaimFormViewModel : BaseViewModel { }
