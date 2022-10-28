namespace XClaim.Mobile.Views;

public class EmptyItemView : ContentView
{
    public EmptyItemView() => Build();

	void Build()
	{
        Content = new StackLayout {
            Children = {
            new Image().Source(Icons.EmptyBanner)
            .Height(165)
            .CenterHorizontal(),
            new Label().Text("No data to display")
            .Font(size: 18)
            .Margins(0, 24)
            .DynamicResource(Label.TextColorProperty, "Primary")
            .CenterHorizontal()
            }
        }.Padding(24);
    }
}