using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

internal class DemoOneView : BaseView<DemoOneViewModel>
{
    enum FrameRow { First, Second }
    enum FrameColumn { First, Second }

    public DemoOneView(DemoOneViewModel demoViewModel) : base(demoViewModel)
    {
        Background = new LinearGradientBrush() {
            StartPoint = new Point(0, 0),
            GradientStops = {
                new GradientStop { Color = Colors.Indigo, Offset = 0.1F },
                new GradientStop { Color = Colors.LightSteelBlue, Offset = 0.8F }
            }
        };
        Content = new VerticalStackLayout
        {
            Children = {
                 new Label().Text("Demo view!").TextCenterHorizontal().TextCenterVertical(),
                 new HorizontalStackLayout() {
                    Children = {
                        new AvatarView {
                             BorderColor = Color.FromArgb("8742f5"),
                             BackgroundColor = Colors.White,
                             BorderWidth = 1,
                             Text = "AK"
                         }
                         .Font(size: 22)
                         .TextColor(Color.FromArgb("8742f5"))
                         .Size(48, 48),
                         new AvatarView() {
                             BackgroundColor = Color.FromArgb("c9a9fc"),
                             ClassId = "Elevation3",
                             Content = new Image().Source(new FontImageSource() {
                                    FontFamily = "FASolid", Glyph = FA.Solid.House, Color = Colors.White
                             }).Size(18)
                         }.Size(48, 48),
                    }
                 }.CenterHorizontal(),
                 new Frame {
                     BackgroundColor = Color.FromArgb("c9a9fc"),
                     Content = new Label().Text("XXX"),
                     CornerRadius = 8,
                     BorderColor = Colors.Transparent,
                     StyleClass = new List<string> { "Elevation1" }
                 }.Size(250, 100),
                 new Label { Padding = 8, Margin = 8 }
                    .Text("Text Two")
                    // Style Extension: .SetStyle("BlueLabel")
                    .DynamicResources((StyleProperty, "BlueLabel")),
                 new ActivityIndicator()  { Color = Colors.Crimson }
                    .Bind(IsVisibleProperty, nameof(DemoOneViewModel.Loading))
                    .Bind(ActivityIndicator.IsRunningProperty, nameof(DemoOneViewModel.Loading)),
                 new ScrollView {
                     Content = new CollectionView() { SelectionMode = SelectionMode.Single }
                     .EmptyViewTemplate(new DataTemplate(() => new Label().Text("The Collection is Empty")))
                     .Bind(ItemsView.ItemsSourceProperty, nameof(DemoOneViewModel.Items))
                     .Bind(SelectableItemsView.SelectedItemProperty, nameof(DemoOneViewModel.Selected))
                     .ItemTemplate(new DataTemplate(() => new Grid
                     {
                         Padding = 10,
                         RowDefinitions = Rows.Define(
                                   (FrameRow.First, Auto),
                                   (FrameRow.Second, Auto)
                               ),
                         ColumnDefinitions = Columns.Define(
                                   (FrameColumn.First, Star),
                                   (FrameColumn.Second, Auto)
                            ),
                         Children = {
                                new HorizontalStackLayout () {
                                    Children = {
                                        new Label()
                                        .Bind(Label.TextProperty, nameof(DemoDto.First))
                                        .TextColor(Colors.Fuchsia)
                                        .Margins(5, 0, 5, 0),
                                        new Label()
                                        .Bind(Label.TextProperty, nameof(DemoDto.Third))
                                        .TextColor(Colors.DarkKhaki),
                                    }
                                }.Row(FrameRow.First).Column(FrameColumn.First),
                                new Image().Source(new FontImageSource() {
                                    FontFamily = "FASolid", Glyph = FA.Solid.User, Color = Colors.Orange
                                }).Size(16)
                                  .Row(FrameRow.First)
                                  .Column(FrameColumn.First),
                                new Label { Padding = 1, Margin = 2 }
                                    .Bind(Label.TextProperty, nameof(DemoDto.Second))
                                    .Row(FrameRow.Second)
                                    .Column(FrameColumn.First),
                                new Image().Source(new FontImageSource() {
                                    FontFamily = "FASolid", Glyph = FA.Solid.EllipsisVertical, Color = Colors.Grey
                                }).Size(16).RowSpan(1).Row(FrameRow.Second).Column(FrameColumn.Second)
                         }
                     }
                     ))
                 }.FillVertical(),
                 new Button(){
                     StyleClass = new List<string> { "FilledButton", "Elevation2" },
                     BackgroundColor = Colors.Indigo,
                     VerticalOptions = LayoutOptions.End
                 }
                .Text("Material Button")
                .Margins(8,5,8,5)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.GetItemsCommand.Execute(null);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args) {
        base.OnNavigatedTo(args);
    }
}

internal partial class DemoOneViewModel : BaseViewModel {
    [ObservableProperty]
    private ObservableCollection<DemoDto> _items = new();

    [ObservableProperty]
    private DemoDto _selected;

    [ObservableProperty]
    private bool _loading = true;

    [RelayCommand]
    private async void GetItems() {
        var NewItems = new List<DemoDto>() {
            new DemoDto("test a 1", "Test a 2"),
            new DemoDto("test b 1", "Test b 2"),
            new DemoDto("test c 1", "Test c 2"),
            new DemoDto("test d 1", "Test d 2"),
            new DemoDto("test e 1", "Test e 2"),
            new DemoDto("test f 1", "Test f 2")
        };
        // Option: Items.Clear();
        await Task.Delay(2500);
        if(NewItems.Count > 0) Loading = false;
        foreach (var item in NewItems) _items.Add(item);
    }
}

internal record DemoDto(string First, string Second, string Third = "Default");
