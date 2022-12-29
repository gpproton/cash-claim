using XClaim.Mobile.Views.Home;

namespace XClaim.Mobile.Views.Profile;

public record ProfileLink(string Name, string Icon, string Route);

public class ProfileView : BaseView<ProfileViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }

    public ProfileView(ProfileViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Content = new Grid {
            ColumnSpacing = 10,
            Margin = 8,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Auto),
                (SectionLevel.Third, Auto),
                (SectionLevel.Fourth, Star),
                (SectionLevel.Fifth, Auto)
            ),
            Children = {
                new HorizontalStackLayout {
                    new Image()
                    .TapGesture(async () => await Shell.Current.GoToAsync($"///{nameof(HomeView)}"))
                    .Source(new FontImageSource() {
                        FontFamily = "FASolid",
                        Glyph = FA.Solid.Xmark,
                        Color = Colors.Grey
                    }).Size(28)
                }.Paddings(8, 2, 0, 0)
                .Row(SectionLevel.First),
                new VerticalStackLayout {
                        Spacing = 2,
                        Children = {
                            new AvatarView() {
                                    CornerRadius = 45,
                                    Content = new Image().Source(new FontImageSource() {
                                        FontFamily = "FASolid",
                                        Glyph = FA.Solid.User,
                                        Color = Colors.White
                                    }).Size(48)
                                }.BackgroundColor(Colors.Gray)
                                .Size(90, 90),
                            new Label().Text("Saurav Argawal").Font(size: 22, family: "RobotoMedium")
                                .CenterHorizontal(),
                            new Label().Text("Administrator").CenterHorizontal()
                        }
                    }
                    .CenterHorizontal()
                    .Row(SectionLevel.Second),
                new Button().Text("Update Profile")
                    .Paddings(24, 8, 24, 8)
                    .Margins(0, 16, 0, 24)
                    .DynamicResource(BackgroundColorProperty, "Secondary")
                    .CenterHorizontal()
                    .Row(SectionLevel.Third),
                new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        Children = {
                            new CollectionView() { SelectionMode = SelectionMode.Single }
                                .Bind(ItemsView.ItemsSourceProperty, nameof(ProfileViewModel.Items))
                                .Invoke(cx => cx.SelectionChanged += HandleSelectionChanged)
                                .ItemTemplate(new DataTemplate(() => new Grid {
                                    RowDefinitions = Rows.Define(
                                        (SectionLevel.First, Auto),
                                        (SectionLevel.Second, 1)
                                    ),
                                    ColumnDefinitions = Columns.Define(
                                        (SectionLevel.First, Auto),
                                        (SectionLevel.Second, Star),
                                        (SectionLevel.Third, Auto)
                                    ),
                                    ColumnSpacing = 5,
                                    Children = {
                                        new Image()
                                            .Margins(2, 4, 4, 2)
                                            .Source(new FontImageSource() {
                                                    FontFamily = "FASolid",
                                                    Glyph = FA.Solid.PiggyBank,
                                                    Color = Colors.DarkGray
                                                }.Bind(FontImageSource.GlyphProperty, nameof(ProfileLink.Icon))
                                            ).Size(24)
                                            .Row(SectionLevel.First)
                                            .Margins(8, 0, 0, 0)
                                            .Column(SectionLevel.First),
                                        new Label { TextColor = Color.FromRgba("#7F7F7F") }
                                            .Font(size: 18)
                                            .Bind(Label.TextProperty, nameof(ProfileLink.Name))
                                            .Row(SectionLevel.First)
                                            .CenterVertical()
                                            .Column(SectionLevel.Second),
                                        new Image().Source(new FontImageSource() {
                                                FontFamily = "FASolid",
                                                Glyph = FA.Solid.ChevronRight,
                                                Color = Colors.Gray
                                            }).Size(28)
                                            .Margins(0, 0, 8, 0)
                                            .Row(SectionLevel.First)
                                            .Column(SectionLevel.Third),
                                        new BoxView()
                                            .DynamicResource(StyleProperty, "SeparatorLine")
                                            .Row(SectionLevel.Second)
                                            .ColumnSpan(3)
                                            .Margins(0, 8, 0, 0)
                                    }
                                }.FillVertical()
                                .Paddings(4, 8, 4, 4)))
                        }
                    }
                    .FillVertical()
                    .Row(SectionLevel.Fourth),
                new Button().Text("Sign Out")
                    .DynamicResource(StyleProperty, "ButtonLargePrimary")
                    .CenterVertical()
                    .Margins(16, 16, 16, 24)
                    .Row(SectionLevel.Fifth)
            }
        };
    }

    async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        ArgumentNullException.ThrowIfNull(sender);
        var cx = (CollectionView)sender;
        cx.SelectedItem = null;
        if (e.CurrentSelection.FirstOrDefault() is ProfileLink link) {
            if (!string.IsNullOrEmpty(link.Route))
                await Shell.Current.GoToAsync(link.Route);
            else
                await DisplayAlert("Invalid Shell", "Fix shell path", "OK");
        }
    }
}

public partial class ProfileViewModel : BaseViewModel {
    const string root = $"///{nameof(ProfileView)}";
    [ObservableProperty] private ObservableCollection<ProfileLink> _items = new() {
        new ProfileLink("Bank Account", FA.Solid.Wallet, $"{root}/{nameof(BankView)}"),
        new ProfileLink("Account History", FA.Solid.CalendarDay, $"{root}/{nameof(LogView)}"),
        new ProfileLink("Appearance", FA.Solid.Sun, $"{root}/{nameof(ThemeView)}"),
        new ProfileLink("Notification", FA.Solid.Bell, $"{root}/{nameof(AlertsView)}"),
        new ProfileLink("Help", FA.Solid.CircleInfo, $"{root}/{nameof(HelpView)}")
    };
}