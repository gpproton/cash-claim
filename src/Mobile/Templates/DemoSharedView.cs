namespace XClaim.Mobile.Templates;

public class DemoSharedView : ContentView
{
	public string SampleTitle
	{
		get => (string)GetValue(SampleTitleProperty);
		set => SetValue(SampleTitleProperty, value);
	}
    public static readonly BindableProperty SampleTitleProperty = BindableProperty.Create(
    nameof(SampleTitle),
    typeof(string),
    typeof(DemoSharedView),
    "Default Title");

    public string SampleDesc
    {
        get => (string)GetValue(SampleDescProperty);
        set => SetValue(SampleDescProperty, value);
    }

    public static readonly BindableProperty SampleDescProperty = BindableProperty.Create(
    nameof(SampleDesc),
    typeof(string),
    typeof(DemoSharedView),
    "Default Desc");

    public DemoSharedView()
	{
		BindingContext = this;
		Content = new StackLayout
		{
			Children = {
				new Label()
				.CenterHorizontal()
				.Font(size: 24, family: "RobotoBold")
				.Bind(Label.TextProperty, nameof(SampleTitle)),
                new Label()
				.CenterHorizontal()
				.Bind(Label.TextProperty, nameof(SampleDesc))
            }
		};
	}
}