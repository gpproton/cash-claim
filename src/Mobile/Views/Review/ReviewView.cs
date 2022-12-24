using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Review;

public class ReviewView : BaseView<ReviewViewModel> {
    enum SectionLevel { First, Second, Third }

    public ReviewView(ReviewViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Build();
    }

    protected override void Build() {
        Title = "Reviews";
        Content = new VerticalStackLayout {
            Children = {
                new ScrollView {
                      Content = Content = new CollectionView() { SelectionMode = SelectionMode.None }
                     .EmptyViewTemplate(new DataTemplate(() =>  new EmptyItemView().Margins(0, 56)))
                     .Bind(ItemsView.ItemsSourceProperty, nameof(ReviewViewModel.Items))
                     .Bind(SelectableItemsView.SelectedItemProperty, nameof(ReviewViewModel.Selected))
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
                          new AvatarView() {
                            CornerRadius = 8,
                            Margin = 4,
                            Content = new Image().Source(new FontImageSource() {
                            FontFamily = "FASolid",
                            Glyph = FA.Solid.Book,
                            Color = Colors.Indigo
                            }).Size(24)
                        }.BackgroundColor(Colors.LightGray)
                        .Size(48, 48)
                        .Column(SectionLevel.First)
                        .RowSpan(2),
                         new Label { TextColor = Color.FromRgba("#7F7F7F") }
                            .Font(size: 14)
                            .Bind(Label.TextProperty, nameof(ReviewDto.Name))
                            .Row(SectionLevel.First)
                            .Column(SectionLevel.Second)
                            .Margins(0, 8, 0, 0),
                          new HorizontalStackLayout {
                              Children = {
                                 new Label()
                                .Font(size: 11)
                                .Bind(Label.TextProperty, nameof(ReviewDto.Time), convert: (DateTime value) => value.ToString("dd-MMM-yyyy")),
                                new Label()
                                .Font(size: 11)
                                .Text(".")
                                .Margins(3, 0, 3, 0),
                                 new Label()
                                 .Font(size: 11)
                                .Bind(Label.TextProperty, nameof(ReviewDto.Owner))
                              }
                          }.Row(SectionLevel.Second)
                          .Column(SectionLevel.Second),
                         new Label { TextColor = Colors.LightGray }
                            .Font(size: 18)
                            .Bind(Label.TextProperty, nameof(ReviewDto.Amount), convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
                            .MinWidth(95)
                            .Row(SectionLevel.First)
                            .Column(SectionLevel.Third)
                            .CenterVertical()
                            .CenterHorizontal(),
                         new Label()
                            .Font(size: 11)
                            .Bind(Label.TextProperty, nameof(ReviewDto.Status))
                            .Row(SectionLevel.Second)
                            .Column(SectionLevel.Third),
                         new BoxView()
                             .DynamicResource(StyleProperty, "SeparatorLine")
                             .Row(SectionLevel.Third)
                             .ColumnSpan(3)
                        }
                     }.Paddings(4, 8, 4, 4)))
                    }.FillVertical()
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadCommand.Execute(null);
    }
}

public partial class ReviewViewModel : BaseViewModel {
    [ObservableProperty]
    private ObservableCollection<ReviewDto> _items;

    [ObservableProperty]
    private ObservableCollection<ReviewDto> _selected;

    [RelayCommand]
    private void Load() {
        Items = new ObservableCollection<ReviewDto>() {
            new ReviewDto("Travel expense calabar", "Saurav Argawal", 7000, DateTime.Now.AddHours(-4), "Reviwed"),
        };
    }
}
