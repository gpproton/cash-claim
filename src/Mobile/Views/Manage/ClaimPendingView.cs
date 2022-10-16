using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Manage;

public class ClaimPendingView : ContentPage
{
	public ClaimPendingView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim pending view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}