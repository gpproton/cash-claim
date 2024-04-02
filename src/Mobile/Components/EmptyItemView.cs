namespace XClaim.Mobile.Components;

public class EmptyItemView : ContentView {
    public EmptyItemView() {
        Build();
    }

    private void Build() {
        Content = new StackLayout {
            Children = {
                new Image().Source(Icons.EmptyBanner)
                    .Height(165)
                    .CenterHorizontal(),
                new Label { TextColor = AppColors.Primary }.Text("No data to display")
                    .Font(size: 18)
                    .Margins(0, 24)
                    .CenterHorizontal()
            }
        }.Padding(24);
    }
}