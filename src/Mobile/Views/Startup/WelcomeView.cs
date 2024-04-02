namespace XClaim.Mobile.Views.Startup;

public class WelcomeView : BaseView<WelcomeViewModel> {
    private enum PageRow {
        First,
        Second
    }

    public WelcomeView(WelcomeViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Background = Gradients.AppGradient;
        Content = new Grid() {
            RowDefinitions = Rows.Define(
                (PageRow.First, Star),
                (PageRow.Second, 140)
            ),
            Children = {
                new Image() {
                        HeightRequest = 320,
                        MaximumHeightRequest = 768,
                        Aspect = Aspect.AspectFill
                    }
                    .Source(Icons.WelcomeBanner)
                    .CenterHorizontal()
                    .Row(PageRow.First),
                new VerticalStackLayout() {
                        Children = {
                            new Button()
                                .Text(AppConst.WelcomeGreeting)
                                .Style(ButtonStyle.LargeLight)
                                .CenterVertical()
                                .Invoke(l => l.Clicked += async (sender, args) =>
                                    await Shell.Current.GoToAsync($"//{nameof(AuthView)}")
                                )
                        }
                    }
                    .Row(PageRow.Second)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
    }
}

public partial class WelcomeViewModel : BaseViewModel { }