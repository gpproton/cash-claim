using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Manage;

public class ClaimHistoryView : ContentPage
{
	public ClaimHistoryView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim history view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}