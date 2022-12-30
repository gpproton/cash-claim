using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Payment;

public class PaymentView : BaseView<PaymentViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public PaymentView(PaymentViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        }.Bind(ToolbarItem.CommandProperty, nameof(PaymentViewModel.ToggleFilterCommand)));
        Build();
    }

    protected override void Build() {
        Title = "Payments";
        Content = new Grid {
            Padding = 4,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Star)
            ),
            Children = {
                new FilterToolbarView()
                    .Bind(FilterToolbarView.StartDateProperty, nameof(PaymentViewModel.StartDate), mode: BindingMode.TwoWay)
                    .Bind(FilterToolbarView.EndDateProperty, nameof(PaymentViewModel.EndDate), mode: BindingMode.TwoWay)
                    .Bind(IsVisibleProperty, nameof(PaymentViewModel.ShowFilter))
                    .Row(SectionLevel.First),
                new RefreshView {
                    Content = new CollectionView() { SelectionMode = SelectionMode.None }
                        .EmptyViewTemplate(new DataTemplate(() => new EmptyItemView().Margins(0, 56)))
                        .Bind(ItemsView.ItemsSourceProperty, nameof(PaymentViewModel.Items))
                        .Bind(SelectableItemsView.SelectedItemProperty, nameof(PaymentViewModel.Selected))
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
                                    .Bind(Label.TextProperty, nameof(PaymentDto.Name))
                                    .Row(SectionLevel.First)
                                    .Column(SectionLevel.Second)
                                    .Margins(0, 8, 0, 0),
                                new HorizontalStackLayout {
                                        Children = {
                                            new Label()
                                                .Font(size: 11)
                                                .Bind(Label.TextProperty, nameof(PaymentDto.Category)),
                                            new Label()
                                                .Font(size: 11)
                                                .Text(".")
                                                .Margins(3, 0, 3, 0),
                                            new Label()
                                                .Font(size: 11)
                                                .Bind(Label.TextProperty, nameof(PaymentDto.Time),
                                                    convert: (DateTime value) => value.ToString("dd-MMM-yyyy"))
                                        }
                                    }.Row(SectionLevel.Second)
                                    .Column(SectionLevel.Second),
                                new Label { TextColor = Colors.LightGreen }
                                    .Font(size: 18)
                                    .Bind(Label.TextProperty, nameof(PaymentDto.Amount),
                                        convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
                                    .MinWidth(95)
                                    .Row(SectionLevel.First)
                                    .Column(SectionLevel.Third)
                                    .CenterVertical()
                                    .CenterHorizontal(),
                                new Label()
                                    .Font(size: 11)
                                    .Bind(Label.TextProperty, nameof(PaymentDto.Status))
                                    .Row(SectionLevel.Second)
                                    .Column(SectionLevel.Third),
                                new BoxView()
                                    .DynamicResource(StyleProperty, "SeparatorLine")
                                    .Row(SectionLevel.Third)
                                    .ColumnSpan(3)
                            }
                        }.Paddings(0, 4, 0, 0)))
                }.Row(SectionLevel.Second)
                .Bind(RefreshView.CommandProperty, nameof(PaymentViewModel.RefreshItemsCommand))
                .Bind(RefreshView.IsRefreshingProperty, nameof(PaymentViewModel.IsRefreshing))
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadCommand.Execute(null);
    }
}

public partial class PaymentViewModel : ListViewModel {
    [ObservableProperty] private ObservableCollection<PaymentDto> _items;

    [ObservableProperty] private ObservableCollection<PaymentDto> _selected;

    [ObservableProperty] private DateTime _startDate;

    [ObservableProperty] private DateTime _endDate;

    [ObservableProperty] private bool _showFilter;

    [RelayCommand]
    private void ToggleFilter() => ShowFilter = !ShowFilter;

    [RelayCommand]
    private void Load() {
        StartDate = DateTime.Now.AddDays(-7);
        EndDate = DateTime.Now;
        Items = new ObservableCollection<PaymentDto>() {
            new("Travel expense calabar", "Transport", 7000, DateTime.Now.AddHours(-4)),
            new("20 Litre Petrol", "Fuel", 1000, DateTime.Now.AddDays(-1), "Pending"),
            new("Spectranet 4G max", "Internet", 30000, DateTime.Now.AddDays(-3))
        };
    }
}