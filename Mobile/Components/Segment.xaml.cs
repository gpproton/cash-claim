#pragma warning disable
#nullable enable
namespace CashClaim.Mobile.Components;

internal enum DefaultState {
    First,
    Second,
    Third
}

public partial class Segment : ContentView {
    private static string[] defaultItems = Enum.GetNames(typeof(DefaultState));

    [BindableProp] private string[] _segmentItems = defaultItems;

    [BindableProp] private string _selectedItem = defaultItems[0];

    public Segment() {
        InitializeComponent();
    }

    private async void OnItemClicked(object sender, EventArgs args) {
        SelectedItem = (sender as Button).Text;
    }
}