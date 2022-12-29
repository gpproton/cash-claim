namespace XClaim.Mobile.Views.Profile;

public class HelpView : BaseView<HelpViewModel> {
    public HelpView(HelpViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Help";
        Content = new VerticalStackLayout {
           new Label().Text("Help!!")
       };
    }
}

public partial class HelpViewModel : BaseViewModel { }