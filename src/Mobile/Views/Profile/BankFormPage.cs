namespace XClaim.Mobile.Views.Profile;

public class BankFormPage : BaseView {
    public BankFormPage() => Build();

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
