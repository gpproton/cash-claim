#pragma warning disable
#nullable enable
namespace XClaim.Mobile.Views;
enum DefaultState { First, Second, Third }
public partial class Segment : ContentView {
    static string[] defaultItems = Enum.GetNames(typeof(DefaultState));

    [BindableProp]
    private string[] _segmentItems = defaultItems;

    [BindableProp]
    private string _selectedItem = defaultItems[0];

    public Segment() {
        InitializeComponent();
    }

    async void OnItemClicked(object sender, EventArgs args) {
        SelectedItem = (sender as Button).Text;
    }
}