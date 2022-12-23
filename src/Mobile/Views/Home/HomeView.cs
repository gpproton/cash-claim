using Microsoft.Maui.Controls.Shapes;
using XClaim.Mobile.Views.Profile;
using XClaim.Mobile.Views.Claim;

namespace XClaim.Mobile.Views.Home;

internal enum PageRow { First, Second, Third, Fourth }
internal enum HeaderRows { First, Second }
internal enum HeaderColumns { First, Second, Third }
internal enum ListTitleColumn { First, Second }

public class HomeView : BaseView<HomeViewModel> {
    public HomeView(HomeViewModel vm) : base(vm) => Build();

    protected override void Build() => Content = new Grid() {
        RowDefinitions = Rows.Define(
            (PageRow.First, 85),
            (PageRow.Second, 115),
            (PageRow.Third, Star),
            (PageRow.Fourth, Auto)
        ),
        Children = {
            new Grid() {
                ColumnDefinitions = Columns.Define(
                    (HeaderColumns.First, Auto),
                    (HeaderColumns.Second, Star),
                    (HeaderColumns.Third, Auto)
                ),
                Children = {
                    new AvatarView() {
                        Content = new Image().Source(new FontImageSource() {
                            FontFamily = "FASolid",
                            Glyph = FA.Solid.User,
                            Color = Colors.White
                        }).Size(28)
                    }.Size(54, 54)
                    .CenterVertical()
                    .DynamicResource(BackgroundColorProperty, "Gray300")
                    .TapGesture(async () => await Shell.Current.GoToAsync(nameof(ProfileView)))
                    .Column(HeaderColumns.First),
                    new StackLayout {
                        Children = {
                            new Label().Text("Hello")
                            .DynamicResource(Label.TextColorProperty, "Secondary"),
                            new Label().Text("Saurav")
                            .Font(size: 20, family: "RobotoBold")
                            .Margins(0, -5, 0, 0)
                            .DynamicResource(Label.TextColorProperty, "Gray500")
                        }
                    }.Margins(8, 16, 0, 0)
                    .Column(HeaderColumns.Second),
                    new Image().Source(new FontImageSource() {
                        FontFamily = "FASolid",
                        Glyph = FA.Solid.Bell
                    }.DynamicResource(FontImageSource.ColorProperty, "Primary"))
                    .Size(28)
                    .CenterVertical()
                    .TapGesture(async () => await Shell.Current.GoToAsync($"///{nameof(HomeView)}/{nameof(NotificationView)}"))
                    .Column(HeaderColumns.Third)
                }
            }
            .Paddings(24, 8, 24, 8)
            .Row(PageRow.First),
            new Border() {
                Padding = 16,
                StrokeThickness = 0F,
                StrokeShape = new RoundRectangle {
                    CornerRadius = new CornerRadius(10)
                },
                Background = Gradients.AppGradient,
                Shadow = new Shadow {
                    Offset = new Point(4, 8),
                    Opacity = 0.5F,
                    Radius = 5,
                    Brush = new LinearGradientBrush {
                        GradientStops = {
                            new GradientStop {
                                Offset = 0.1F,
                                Color = Colors.Grey
                            },
                            new GradientStop {
                                Offset = 1.0F,
                                Color = Colors.LightGray
                            }
                        }
                    }
                },
                Content = new StackLayout() {
                    Children = {
                        new Label()
                        .Text("Pending Claims")
                        .Font(size: 14)
                        .TextColor(Colors.White)
                        .Margins(0, 0, 0, 4),
                        new Label()
                        .Text("\u20A6" + "10,000")
                        .TextColor(Colors.White)
                        .Font(size: 32, family: "RobotoBold")
                    }
                }
            }
            .Margins(24, 6, 24, 6)
            .Row(PageRow.Second),
            new VerticalStackLayout() {
                new Grid() {
                    ColumnDefinitions = Columns.Define(
                        (ListTitleColumn.First, Star),
                        (ListTitleColumn.Second, Auto)
                    ),
                    Padding = 4,
                    Children = {
                        new Label()
                        .Text("Recents")
                        .Font(size: 16)
                        .Column(ListTitleColumn.First)
                        .DynamicResource(Label.TextColorProperty, "Gray300"),
                        new Label()
                        .Text("See all")
                        .Font(size: 16)
                        .TapGesture(async () => await Shell.Current.GoToAsync($"//{nameof(ClaimView)}"))
                        .Column(ListTitleColumn.Second)
                        .DynamicResource(Label.TextColorProperty, "Primary")
                    }
                },


                // TODO: Use RefreshView with ScrollView
                //new RefreshView {
                //    Content = new ScrollView {}
                //}.Bind(RefreshView.IsRefreshingProperty, nameof(HomeViewModel.RecentItemsIsRefreshing))
                //.Bind(RefreshView.CommandProperty, nameof(HomeViewModel.RefreshRecentsCommand))

                new ScrollView {
                      Content = Content = new CollectionView() { SelectionMode = SelectionMode.Single }
                     .EmptyViewTemplate(new DataTemplate(() => new Label().Text("The Collection is Empty")))
                     .Bind(ItemsView.ItemsSourceProperty, nameof(HomeViewModel.RecentItems))
                     .Bind(SelectableItemsView.SelectedItemProperty, nameof(HomeViewModel.SelectedRecentItem))
                     .ItemTemplate(new DataTemplate(() => new Grid {
                        Padding = 10,
                        ColumnDefinitions = Columns.Define(
                            (PageRow.First, Auto),
                            (PageRow.Second, Star),
                            (PageRow.Third, Auto)
                        ),
                        RowDefinitions = Rows.Define(
                            (PageRow.First, Auto),
                            (PageRow.Second, Auto)
                        ),

                        Children = {
                          new Label { Padding = 1, Margin = 2 }
                            .Font(size: 16)
                            .Bind(Label.TextProperty, nameof(TempRecent.Name))
                            .Row(PageRow.First)
                            .Column(PageRow.First),

                          new HorizontalStackLayout {
                              Children = {
                                 new Label { Padding = 1, Margin = 2 }
                                 .Font(size: 11)
                                .Bind(Label.TextProperty, nameof(TempRecent.Category)),
                                new Label { Padding = 1, Margin = 2 }
                                .Font(size: 11)
                                .Text("."),
                                new Label { Padding = 1, Margin = 2 }
                                .Font(size: 11)
                                .Text("3 Hours ago")
                              }
                          }.Row(PageRow.Second)
                          .Column(PageRow.First),

                         new Label { TextColor = Colors.Green }
                        .Font(size: 22, family: "RobotoMedium")
                        .Bind(Label.TextProperty, nameof(TempRecent.Amount), convert: (int value) => "₦" + value)
                        .Width(95)
                        .Row(PageRow.First)
                        .RowSpan(2)
                        .Column(PageRow.Third)
                        .CenterVertical()
                        }
                     }))
                    }.FillVertical()

            }
            .Margins(16, 16, 16, 8)
            .Row(PageRow.Third),

            new Button().Text("New Request")
            .DynamicResource(StyleProperty, "ButtonLargePrimary")
            .CenterVertical()
            .Margins(24, 16, 24, 24)
            .BindCommand(nameof(HomeViewModel.ToClaimFormCommand))
            .Row(PageRow.Fourth)
        }
    };
    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadRecentItemsCommand.Execute(null);
    }
}

public record TempRecent(string Name, string Category, int Amount);

public partial class HomeViewModel : BaseViewModel {
    [ObservableProperty]
    private ObservableCollection<TempRecent> _recentItems;


    [ObservableProperty]
    private bool _recentItemsIsRefreshing = false;

    [ObservableProperty]
    private TempRecent _selectedRecentItem;

    [ObservableProperty]
    private bool _loading = true;

    [RelayCommand]
    private async void LoadRecentItems() {
        Loading = true;
        await Task.Delay(500);
        RecentItems = new ObservableCollection<TempRecent> {
            new TempRecent("Travel expense calabar", "Transport", 7000),
            new TempRecent("20 Litre Petrol", "Fuel", 1000),
            new TempRecent("Spectranet 4G max", "Internet", 30000)
        };
        Loading = false;
    }

    [RelayCommand]
    private async void RefreshRecents() {
        RecentItemsIsRefreshing = true;
        await Task.Delay(1500);
        RecentItemsIsRefreshing = false;
    }

    [RelayCommand]
    private async void ToClaimForm() => await Shell.Current.GoToAsync($"///{nameof(HomeView)}/{nameof(ClaimFormView)}");
}
