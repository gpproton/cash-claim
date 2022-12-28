using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Claim;

internal enum StatusOptions {
    Confirmed,
    Pending,
    Completed
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
        Content = new VerticalStackLayout {
            Children = {
                new FilterToolbarView(),
                new Segment().Margins(8, 4, 8, 4)
                    .Bind(Segment.SegmentItemsProperty, nameof(ClaimViewModel.StatusItems))
                    .Bind(Segment.SelectedItemProperty, nameof(ClaimViewModel.StatusValue), BindingMode.TwoWay),

                // TODO: sample for time picker.
                // new TimePickerField { Title = "Time Sample", Time = DateTime.Now.AddMinutes(15).TimeOfDay }.Margins(0, 8, 0,8)

                new ScrollView {
                    Content = Content = new CollectionView() { SelectionMode = SelectionMode.None }
                        .EmptyViewTemplate(new DataTemplate(() => new Label().Text("The Collection is Empty")))
                        .Bind(ItemsView.ItemsSourceProperty, nameof(ClaimViewModel.Items))
                        .Bind(SelectableItemsView.SelectedItemProperty, nameof(ClaimViewModel.Selected))
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

public partial class ClaimViewModel : BaseViewModel {
    [ObservableProperty] private string[] _statusItems;

    [ObservableProperty] private string _statusValue;

    [ObservableProperty] private ObservableCollection<ClaimDto> _items;

    [ObservableProperty] private ObservableCollection<ClaimDto> _selected;

    public ClaimViewModel() {
        StatusItems = Enum.GetNames(typeof(StatusOptions));
        StatusValue = Enum.GetName(StatusOptions.Pending);
    }

    [RelayCommand]
    private void Load() {
        Items = new ObservableCollection<ClaimDto>() {
            new("Travel expense calabar", "Transport", 7000, DateTime.Now.AddHours(-4), "Checked documents already."),
            new("20 Litre Petrol", "Fuel", 1000, DateTime.Now.AddDays(-1), "Total filling station"),
            new("Spectranet 4G max", "Internet", 30000, DateTime.Now.AddDays(-3), "20GB Packages")
        };
    }
}