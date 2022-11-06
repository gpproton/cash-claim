#pragma warning disable
#nullable enable
namespace XClaim.Mobile.Views;

public partial class Segment : ContentView
{
    [AutoBindable]
    private readonly string[]? _segmentItems;

    [AutoBindable]
    private readonly string? _selectedItem;

    public enum ItemState { Pending, Confirmed, Completed }

    public Segment() {
        InitializeComponent();
        if(SegmentItems is null) SegmentItems = Enum.GetNames(typeof(ItemState));
        if(SegmentItems is not null) SelectedItem = SegmentItems[0];
    }

    async void OnItemClicked(object sender, EventArgs args) {
        SelectedItem = (sender as Button).Text;
    }
}