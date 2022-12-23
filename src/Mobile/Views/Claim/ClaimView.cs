using UraniumUI.Material.Controls;
using XClaim.Common.Extensions;

namespace XClaim.Mobile.Views.Claim;

public enum StatusOptions { Confirmed, Pending, Completed }

public class ClaimView : BaseView<ClaimViewModel> {
    public ClaimView(ClaimViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
                new FilterToolbarView(),
                new Segment().Margins(8, 4, 8, 4)
                .Bind(Segment.SegmentItemsProperty, nameof(ClaimViewModel.StatusItems))
                .Bind(Segment.SelectedItemProperty, nameof(ClaimViewModel.StatusValue), mode: BindingMode.TwoWay),

                // TODO: sample for time picker.
                // new TimePickerField { Title = "Time Sample", Time = DateTime.Now.AddMinutes(15).TimeOfDay }.Margins(0, 8, 0,8)

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
