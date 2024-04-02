using Microsoft.Maui.Controls.Shapes;
using CashClaim.Mobile.Views.Profile;
using CashClaim.Mobile.Views.Claim;
using CashClaim.Common.Enums;
using CashClaim.Mobile.Views.Home.Component;

namespace CashClaim.Mobile.Views.Home;

public class HomeView : BaseView<HomeViewModel> {

    enum SectionLevel {
        First,
        Second,
        Third,
        Fourth
    }

    public HomeView(HomeViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new Grid() {
            RowDefinitions = Rows.Define(
                (SectionLevel.First, 85),
                (SectionLevel.Second, 115),
                (SectionLevel.Third, Star),
                (SectionLevel.Fourth, Auto)
            ),
            Children = {
                new Grid() {
                        ColumnDefinitions = Columns.Define(
                            (SectionLevel.First, Auto),
                            (SectionLevel.Second, Star),
                            (SectionLevel.Third, Auto)
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
                                .BackgroundColor(AppColors.Gray300)
                                .TapGesture(async () => await Shell.Current.GoToAsync($"///{nameof(ProfileView)}"))
                                .Column(SectionLevel.First),
                            new StackLayout {
                                    Children = {
                                        new Label() { TextColor = AppColors.Secondary }.Text(AppConst.HomeGreeting),
                                        new Label() { TextColor = AppColors.Gray500 }
                                            .Bind(Label.TextProperty, "Status.FirstName")
                                            .Font(size: 20, family: AppFonts.RobotoBold )
                                            .Margins(0, -5, 0, 0)
                                    }
                                }.Margins(8, 16, 0, 0)
                                .Column(SectionLevel.Second),
                            new Image().Source(new FontImageSource() {
                                    FontFamily = "FASolid",
                                    Glyph = FA.Solid.Bell,
                                    Color = AppColors.Primary
                                })
                                .Size(28)
                                .CenterVertical()
                                .TapGesture(async () =>
                                    await Shell.Current.GoToAsync($"///{nameof(HomeView)}/{nameof(NotificationView)}"))
                                .Column(SectionLevel.Third)
                        }
                    }
                    .Paddings(24, 8, 24, 8)
                    .Row(SectionLevel.First),
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
                                    .Text(AppConst.HomeCardText)
                                    .Font(size: 14)
                                    .TextColor(Colors.White)
                                    .Margins(0, 0, 0, 4),
                                new Label()
                                    .TextColor(Colors.White)
                                    .Font(size: 32, family: AppFonts.RobotoBold)
                                    .Bind(Label.TextProperty, "Status.Balance",
                                        convert: (decimal value) => AppConst.Naira + string.Format("{0:N0}", value))
                            }
                        }
                    }
                    .Margins(24, 6, 24, 6)
                    .Row(SectionLevel.Second),
                new Grid() {
                        RowDefinitions = Rows.Define(
                            (SectionLevel.First, Auto),
                            (SectionLevel.Second, Star)
                        ),
                        Children = {
                            new Grid() {
                                ColumnDefinitions = Columns.Define(
                                    (SectionLevel.First, Star),
                                    (SectionLevel.Second, Auto)
                                ),
                                Padding = 8,
                                Children = {
                                    new Label() { TextColor = AppColors.Gray300 }
                                        .Text(AppConst.HomeRecentTitle)
                                        .Font(size: 16)
                                        .Column(SectionLevel.First),
                                    new Label() { TextColor = AppColors.Primary }
                                        .Text(AppConst.HomeRecentLink)
                                        .Font(size: 16)
                                        .TapGesture(async () => await Shell.Current.GoToAsync($"//{nameof(ClaimView)}"))
                                        .Column(SectionLevel.Second)
                                }
                            }.Row(SectionLevel.First),
                            new RefreshView {
                                    Content = new CollectionView() {
                                            SelectionMode = SelectionMode.Single,
                                            EmptyView = AppConst.EmptyListText
                                        }
                                        .Bind(ItemsView.ItemsSourceProperty, nameof(HomeViewModel.RecentItems))
                                        .Invoke(cx => cx.SelectionChanged += HandleSelectionChanged)
                                        .ItemTemplate(new DataTemplate(() => new Grid {
                                            ColumnDefinitions = Columns.Define(
                                                (SectionLevel.First, Auto),
                                                (SectionLevel.Second, Star),
                                                (SectionLevel.Third, Auto)
                                            ),
                                            RowDefinitions = Rows.Define(
                                                (SectionLevel.First, Auto),
                                                (SectionLevel.Second, Auto),
                                                (SectionLevel.Third, 1)
                                            ),
                                            Children = {
                                                new Label { Padding = 1, Margin = 2, TextColor = AppColors.Gray400 }
                                                    .Font(size: 16)
                                                    .Bind(Label.TextProperty, nameof(EventResponse.Description))
                                                    .Row(SectionLevel.First)
                                                    .Column(SectionLevel.First),
                                                new HorizontalStackLayout {
                                                        Children = {
                                                            new Label { Padding = 1, Margin = 2 }
                                                                .Font(size: 11)
                                                                .Bind(Label.TextProperty,
                                                                    nameof(EventResponse.Type)),
                                                            new Label { Padding = 1, Margin = 2 }
                                                                .Font(size: 11)
                                                                .Text("."),
                                                            new Label { Padding = 1, Margin = 2 }
                                                                .Font(size: 11)
                                                                .Bind(Label.TextProperty, nameof(EventResponse.CreatedAt),
                                                                    convert: (DateTime value) => value.TimeAgo())
                                                        }
                                                    }.Row(SectionLevel.Second)
                                                    .Column(SectionLevel.First),
                                                new Label { TextColor = Colors.LightSeaGreen }
                                                    .Font(size: 22, family: AppFonts.RobotoMedium)
                                                    .Bind(Label.TextProperty, nameof(EventResponse.Claim.Amount),
                                                        convert: (decimal value) =>
                                                           AppConst.Naira + string.Format("{0:N0}", value))
                                                    .MinWidth(105)
                                                    .Row(SectionLevel.First)
                                                    .RowSpan(2)
                                                    .Column(SectionLevel.Third)
                                                    .CenterVertical()
                                                    .CenterHorizontal(),
                                                new BoxView().Style(SharedStyle.HorizontalLine)
                                                    .Row(SectionLevel.Third)
                                                    .ColumnSpan(3)
                                            }
                                        }.Paddings(4, 2, 4, 4)))
                                }.Row(SectionLevel.Second)
                                .Bind(RefreshView.IsRefreshingProperty, nameof(HomeViewModel.IsRefreshing))
                                .Bind(RefreshView.CommandProperty, nameof(HomeViewModel.RefreshItemsCommand))
                        }
                    }
                    .Margins(8, 16, 8, 8)
                    .Row(SectionLevel.Third),

                new Button()
                    .Style(ButtonStyle.LargePrimary)
                    .Invoke(l => l.Command = new Command(async () =>
                            await Shell.Current.GoToAsync($"///{nameof(HomeView)}/{nameof(ClaimFormView)}")))
                    .Text(AppConst.HomeActionText)
                    .CenterVertical()
                    .Margins(24, 16, 24, 24)
                    .Row(SectionLevel.Fourth)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadDefaultsCommand.Execute(null);
    }

#nullable enable
    private async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        ArgumentNullException.ThrowIfNull(sender);
        var cx = (CollectionView)sender;
        cx.SelectedItem = null;
        if (e.CurrentSelection.FirstOrDefault() is EventResponse item)
            if (item.Id != null)
                await MauiPopup.PopupAction.DisplayPopup(new HomeEventPop(item));
    }
}

public partial class HomeViewModel : ListViewModel {
    [ObservableProperty] private ObservableCollection<EventResponse>? _recentItems;

    [ObservableProperty] private UserResponse? _status;

    [RelayCommand]
    private async Task LoadDefaults() {
        IsLoading = true;
        await Task.Delay(500);
        Status = new UserResponse { FirstName = "Saurav", LastName = "Argawal", Balance = 2000, Permission = UserPermission.Administrator };
        RecentItems = new ObservableCollection<EventResponse> { };
        IsLoading = false;
    }
}