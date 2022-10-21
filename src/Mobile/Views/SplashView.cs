namespace XClaim.Mobile.Views;

public class SplashView : ContentPage
{
	public SplashView() => Content = new VerticalStackLayout
    {
        Children = {
                new Label().Text("Splash view!").TextCenterHorizontal().TextCenterVertical()
        }
    };
}