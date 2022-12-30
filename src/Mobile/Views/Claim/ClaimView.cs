using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Claim;

internal enum FilterOptions {
    Pending,
    Reviewed,
    Confirmed
}

public class ClaimView : BaseView<ClaimViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third,
        Fourth
    }

    public ClaimView(ClaimViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Content = new Grid {
            RowSpacing = 3,
            Padding = 4,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Auto),
                (SectionLevel.Third, Star)
            ),
            Children = {
                new Grid {
                    ColumnDefinitions = Columns.Define(
                        (SectionLevel.First, Star),
                        (SectionLevel.Second, Auto)
                    ),
                    Children = {
                        new FilterToolbarView()
                            .Bind(FilterToolbarView.StartDateProperty, nameof(ClaimViewModel.StartDate),
                                BindingMode.TwoWay)
                            .Bind(FilterToolbarView.EndDateProperty, nameof(ClaimViewModel.EndDate), BindingMode.TwoWay)
                            .Bind(FilterToolbarView.ShowSearchProperty, nameof(ClaimViewModel.ShowSearch),
                                BindingMode.TwoWay)
                            .Bind(FilterToolbarView.SearchProperty, nameof(ClaimViewModel.Search), BindingMode.TwoWay)
                            .Column(SectionLevel.First),
                        new Button {
                                ImageSource = new FontImageSource() {
                                    FontFamily = "FASolid",
                                    Color = Colors.White,
                                    Glyph = FA.Solid.Sliders,
                                    Size = 18
                                } // TODO: fix for GlyphProperty binding
                            }
                            .Height(46)
                            .Paddings(16, 0, 16, 0)
                            .Margins(4, 0, 0, 0)
                            .Bind(Button.CommandProperty, nameof(ClaimViewModel.ToggleSearchCommand))
                            .Column(SectionLevel.Second)
                    }
                }.Row(SectionLevel.First),
                new Segment().Row(SectionLevel.Second)
                    .Bind(Segment.SegmentItemsProperty, nameof(ClaimViewModel.FilterItems))
                    .Bind(Segment.SelectedItemProperty, nameof(ClaimViewModel.FilterValue), BindingMode.TwoWay),
                new RefreshView {
                        Content = new CollectionView() {
                                SelectionMode = SelectionMode.Single,
                                EmptyView = "No item to display"
                            }
                            .Bind(ItemsView.ItemsSourceProperty, nameof(ClaimViewModel.Items))
                            .Bind(SelectableItemsView.SelectedItemProperty, nameof(ClaimViewModel.Selected))
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
                                    (SectionLevel.Third, Auto),
                                    (SectionLevel.Fourth, 1)
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
                                        .RowSpan(3),
                                    new Label { TextColor = Color.FromRgba("#7F7F7F") }
                                        .Font(size: 14)
                                        .Bind(Label.TextProperty, nameof(ClaimDto.Name))
                                        .Row(SectionLevel.First)
                                        .Column(SectionLevel.Second),
                                    new HorizontalStackLayout {
                                            Children = {
                                                new Label()
                                                    .Font(size: 11)
                                                    .Bind(Label.TextProperty, nameof(ClaimDto.Time),
                                                        convert: (DateTime value) => value.ToString("dd-MMM-yyyy")),
                                                new Label()
                                                    .Font(size: 11)
                                                    .Text(".")
                                                    .Margins(3, 0, 3, 0),
                                                new Label()
                                                    .Font(size: 11)
                                                    .Bind(Label.TextProperty, nameof(ClaimDto.Category))
                                            }
                                        }.Row(SectionLevel.Second)
                                        .Column(SectionLevel.Second),
                                    new Label()
                                        .Font(size: 11)
                                        .Bind(Label.TextProperty, nameof(ClaimDto.Notes))
                                        .Row(SectionLevel.Third)
                                        .Column(SectionLevel.Second),
                                    new Label { TextColor = Colors.Grey }
                                        .Font(size: 22)
                                        .Bind(Label.TextProperty, nameof(ClaimDto.Amount),
                                            convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
                                        .MinWidth(105)
                                        .Row(SectionLevel.First)
                                        .RowSpan(3)
                                        .Column(SectionLevel.Third)
                                        .CenterVertical()
                                        .CenterHorizontal(),
                                    new BoxView()
                                        .DynamicResource(StyleProperty, "SeparatorLine")
                                        .Row(SectionLevel.Fourth)
                                        .ColumnSpan(3)
                                }
                            }))
                    }.Row(SectionLevel.Third)
                    .Bind(RefreshView.CommandProperty, nameof(ClaimViewModel.RefreshItemsCommand))
                    .Bind(RefreshView.IsRefreshingProperty, nameof(ClaimViewModel.IsRefreshing))
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadCommand.Execute(null);
    }

    private async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        ArgumentNullException.ThrowIfNull(sender);
        var cx = (CollectionView)sender;
        cx.SelectedItem = null;
        if (e.CurrentSelection.FirstOrDefault() is ClaimDto item)
            if (!string.IsNullOrEmpty(item.id.ToString()))
                await Shell.Current.GoToAsync($"///{nameof(ClaimView)}/{nameof(ClaimDetailView)}", true,
                    new Dictionary<string, object> {
                        { "Item", item }
                    });
    }
}

public partial class ClaimViewModel : ListViewModel {
    [ObservableProperty] private string[] _filterItems;

    [ObservableProperty] private string _filterValue;

    [ObservableProperty] private DateTime _startDate;

    [ObservableProperty] private DateTime _endDate;

    [ObservableProperty] private bool _showSearch;

    [ObservableProperty] private string _search;

    [ObservableProperty] private ObservableCollection<ClaimDto> _items;

    [ObservableProperty] private ObservableCollection<ClaimDto> _selected;

    public ClaimViewModel() {
        FilterItems = Enum.GetNames(typeof(FilterOptions));
        FilterValue = Enum.GetName(FilterOptions.Pending);
        StartDate = DateTime.Now.AddDays(-7);
        EndDate = DateTime.Now;
    }

    [RelayCommand]
    private void ToggleSearch() {
        ShowSearch = !ShowSearch;
    }

    [RelayCommand]
    private async Task Load() {
        await Task.Delay(100);
        Items = new ObservableCollection<ClaimDto>() {
            new(Guid.NewGuid(), "Travel expense calabar", "Transport", 7000, DateTime.Now.AddHours(-4),
                "Checked documents already."),
            new(Guid.NewGuid(), "20 Litre Petrol", "Fuel", 1000, DateTime.Now.AddDays(-1), "Total filling station"),
            new(Guid.NewGuid(), "Spectranet 4G max", "Internet", 30000, DateTime.Now.AddDays(-3), "20GB Packages")
        };
    }
}