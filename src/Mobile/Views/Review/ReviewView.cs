using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Review;

public class ReviewView : BaseView<ReviewViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public ReviewView(ReviewViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders,
                Size = 22
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        }.Bind(ToolbarItem.CommandProperty, nameof(ReviewViewModel.ToggleFilterCommand))
        );
        Build();
    }

    protected override void Build() {
        Title = "Reviews";
        Content = new Grid {
            Padding = 4,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Star)
            ),
            Children = {
                new FilterToolbarView()
                    .Bind(FilterToolbarView.StartDateProperty, nameof(ReviewViewModel.StartDate), mode: BindingMode.TwoWay)
                    .Bind(FilterToolbarView.EndDateProperty, nameof(ReviewViewModel.EndDate), mode: BindingMode.TwoWay)
                    .Bind(IsVisibleProperty, nameof(ReviewViewModel.ShowFilter))
                    .Row(SectionLevel.First),
                new RefreshView {
                        Content = new CollectionView() {
                                SelectionMode = SelectionMode.Single,
                                EmptyView = "No items to display"
                            }.Bind(ItemsView.ItemsSourceProperty, nameof(ReviewViewModel.Items))
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
                                                    .Bind(Label.TextProperty, nameof(ReviewDto.Time),
                                                        convert: (DateTime value) => value.ToString("dd-MMM-yyyy")),
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
                                    new Label { TextColor = Colors.Gray }
                                        .Font(size: 18)
                                        .Bind(Label.TextProperty, nameof(ReviewDto.Amount),
                                            convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
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
                            }.Paddings(0, 4, 0, 0)))
                    }.Bind(RefreshView.CommandProperty, nameof(ReviewViewModel.RefreshItemsCommand))
                    .Bind(RefreshView.IsRefreshingProperty, nameof(ReviewViewModel.IsRefreshing))
                    .Row (SectionLevel.Second)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadCommand.Execute(null);
    }

    async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        ArgumentNullException.ThrowIfNull(sender);
        var cx = (CollectionView)sender;
        cx.SelectedItem = null;
        if (e.CurrentSelection.FirstOrDefault() is ReviewDto item) {
            if (!string.IsNullOrEmpty(item.Name))
                await DisplayAlert("Sample", "Fix shell path", "OK");
        }
    }
}

public partial class ReviewViewModel : ListViewModel {
    [ObservableProperty] private ObservableCollection<ReviewDto> _items;

    [ObservableProperty] private ObservableCollection<ReviewDto> _selected;

    [ObservableProperty] private DateTime _startDate;

    [ObservableProperty] private DateTime _endDate;

    [ObservableProperty] private bool _showFilter;

    [RelayCommand]
    private void ToggleFilter() => ShowFilter = !ShowFilter;

    [RelayCommand]
    private async Task Load() {
        StartDate = DateTime.Now.AddDays(-7);
        EndDate = DateTime.Now;
        await Task.Delay(100);
        Items = new ObservableCollection<ReviewDto>() {
            new("Travel expense calabar", "Saurav Argawal", 7000, DateTime.Now.AddHours(-4), "Reviwed")
        };
    }
}