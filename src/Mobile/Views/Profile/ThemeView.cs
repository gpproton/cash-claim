namespace XClaim.Mobile.Views.Profile;

internal class ThemeView : BaseView<ThemeViewModel> {
    public ThemeView(ThemeViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Appearance Setting";
        Content = new VerticalStackLayout {
           new Label().Text("Appearnace!!")
       };
    }
}

public partial class ThemeViewModel : BaseViewModel { }