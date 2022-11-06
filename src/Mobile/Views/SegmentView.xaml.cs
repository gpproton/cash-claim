#pragma warning disable
#nullable enable
namespace XClaim.Mobile.Views;

public partial class SegmentView : ContentView
{
    [AutoBindable]
    private readonly string[] _segmentItems;

    [AutoBindable]
    private readonly string _selectedItem;

    public enum ItemState { Pending, Confirmed, Completed }

    public SegmentView() {
        InitializeComponent();
        if(SegmentItems is null) SegmentItems = Enum.GetNames(typeof(ItemState));
        if(SegmentItems is not null) SelectedItem = SegmentItems[0];
        BindingContext = this;
	}

    async void OnItemClicked(object sender, EventArgs args) {
        SelectedItem = (sender as Button).Text;
    }
}