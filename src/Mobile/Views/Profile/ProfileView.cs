using XClaim.Mobile.Views.Home;

namespace XClaim.Mobile.Views.Profile;

public record ProfileLink(string Name, string Icon, string Route);

public class ProfileView : BaseView<ProfileViewModel> {
    enum SectionLevel { First, Second, Third, Fourth }

    public ProfileView(ProfileViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Profile";
        Content = new Grid {
            ColumnSpacing = 10,
            Margin = 8,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Auto),
                (SectionLevel.Third, Star),
                (SectionLevel.Fourth, Auto)
            ),
            Children = {
                new StackLayout {
                    Orientation = StackOrientation.Vertical,
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
                        new Label().Text("Saurav Argawal").Font(size: 22, family: "RobotoMedium").CenterHorizontal(),
                        new Label().Text("Administrator").CenterHorizontal(),
                    }
                }
                .CenterHorizontal()
                .Row(SectionLevel.First),

                new Button().Text("Update Profile")
                .Paddings(24, 8, 24, 8)
                .Margins(0, 16, 0, 24)
                .DynamicResource(Button.BackgroundColorProperty, "Secondary")
                .CenterHorizontal()
                .Row(SectionLevel.Second),

                new StackLayout {
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        new CollectionView() { SelectionMode = SelectionMode.None }
                            .EmptyViewTemplate(new DataTemplate(() => new Label().Text("The Collection is Empty")))
                            .Bind(ItemsView.ItemsSourceProperty, nameof(ProfileViewModel.Items))
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
                .Row(SectionLevel.Third),

                new Button().Text("Sign Out")
                .DynamicResource(StyleProperty, "ButtonLargePrimary")
                .CenterVertical()
                .Margins(16, 16, 16, 24)
                .Row(SectionLevel.Fourth)
            }
        };
    }
}

public partial class ProfileViewModel : BaseViewModel {
    [ObservableProperty]
    private ObservableCollection<ProfileLink> _items = new() {
        new ProfileLink("Bank Account", FA.Solid.Wallet, $"///{nameof(HomeView)}/{nameof(BankView)}"),
        new ProfileLink("Account History", FA.Solid.CalendarDay, $"///{nameof(HomeView)}/{nameof(SettingView)}"),
        new ProfileLink("Appearance", FA.Solid.Sun, $"///{nameof(HomeView)}/{nameof(SettingView)}"),
        new ProfileLink("Notification", FA.Solid.Bell, $"///{nameof(HomeView)}/{nameof(SettingView)}"),
        new ProfileLink("Help", FA.Solid.CircleInfo, $"///{nameof(HomeView)}/{nameof(SettingView)}")
    };
}
