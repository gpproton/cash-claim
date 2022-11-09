namespace XClaim.Mobile.Pages.Claim;

public enum StatusOptions { Confirmed, Pending, Completed }

public class ClaimPage : BasePage<ClaimViewModel> {
    public ClaimPage(ClaimViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
                new FilterToolbarView(),
                new Segment().Margins(8, 4, 8, 4)
                .Bind(Segment.SegmentItemsProperty, nameof(ClaimViewModel.StatusItems))
                .Bind(Segment.SelectedItemProperty, nameof(ClaimViewModel.StatusValue), mode: BindingMode.TwoWay),
                new EmptyItemView().Margins(0, 56)
            }
        };
    }
}

public partial class ClaimViewModel : BaseViewModel {
    [ObservableProperty]
    private string[] _statusItems;

    [ObservableProperty]
    private string _statusValue;

    public ClaimViewModel() {
        StatusItems = Enum.GetNames(typeof(StatusOptions));
        StatusValue = Enum.GetName(StatusOptions.Pending);
    }
}
