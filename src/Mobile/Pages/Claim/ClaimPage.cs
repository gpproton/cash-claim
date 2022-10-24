using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Claim;

public class ClaimPage : BasePage<ClaimViewModel>
{
    public ClaimPage(ClaimViewModel claimVm) : base(claimVm) => Content = new VerticalStackLayout
    {
        Children = {
            new Label { Text = "Claim view!!" }
            .TextCenterHorizontal()
            .TextCenterVertical()
        }
    };
}

public class ClaimViewModel : BaseViewModel { }
