using XClaim.Mobile.Templates;
using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Claim;

public class ClaimPage : BasePage<ClaimViewModel>
{
    public ClaimPage(ClaimViewModel claimVm) : base(claimVm) => Build();

    void Build()
    {
        Content = new VerticalStackLayout {
            Children = {
                new RangeFilterToolbar()
            }
        };
    }
}

public class ClaimViewModel : BaseViewModel { }
