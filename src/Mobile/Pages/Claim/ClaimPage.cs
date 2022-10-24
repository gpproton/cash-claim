namespace XClaim.Mobile.Pages.Claim;

public class ClaimPage : ContentPage
{
    public ClaimPage()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { Text = "Claim view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}