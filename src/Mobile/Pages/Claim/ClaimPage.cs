using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Claim;

public class ClaimPage : BasePage<ClaimViewModel> {
    public ClaimPage(ClaimViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
                new FilterToolbarView(),
                new SegmentView(),
                new EmptyItemView().Margins(0, 56)
            }
        };
    }
}

public class ClaimViewModel : BaseViewModel { }
