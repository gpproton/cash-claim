using XClaim.Mobile.Templates;
using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Claim;

public class ClaimPage : BasePage<ClaimViewModel>
{
    public ClaimPage(ClaimViewModel claimVm) : base(claimVm) => Build();

    void Build()
    {
        Content = new VerticalStackLayout {
            Children = {
                new RangeFilterToolbar(),
                new EmptyItemView().Margins(0, 56)
            }
        };
    }
}

public class ClaimViewModel : BaseViewModel { }
