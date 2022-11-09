using XClaim.Mobile.Views;

namespace XClaim.Mobile.Views.Profile;

public class BankView : BaseView {
    public BankView() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label {
                Text = "Bank view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
        };
    }
}
