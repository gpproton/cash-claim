namespace XClaim.Mobile.Views.Profile;

public class BankFormView : BaseView {
    public BankFormView() => Build();

    protected override void Build() {
        Content = new VerticalStackLayout {
            Children = {
            new Label {
                Text = "Bank form view!"
            }.TextCenterHorizontal().TextCenterVertical()
        }
        };
    }
}
