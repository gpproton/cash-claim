using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

internal class DemoOneView : BaseView<DemoOneViewModel>
{
    enum FrameRow { First, Second }
    enum FrameColumn { First, Second }

    public DemoOneView(DemoOneViewModel demoViewModel) : base(demoViewModel) => Content = new VerticalStackLayout {
            Children = {
                 new Label().Text("Demo view!").TextCenterHorizontal().TextCenterVertical(),
                 new AvatarView {
                     BorderColor = Color.FromArgb("7F7F7F"),
                     BackgroundColor = Color.FromArgb("EDEDED"),
                     BorderWidth = 2,
                     Text = "AK"
                 }
                 .Font(size: 22)
                 .TextColor(Color.FromArgb("8742f5"))
                 .Size(48, 48),
                 new AvatarView {
                     BackgroundColor = Color.FromArgb("c9a9fc"),
                     Content = new Image().Size(18, 18).Source("icon_home.svg")
                 }.Size(48, 48),
                 new Frame
                 {
                     BackgroundColor = Color.FromArgb("c9a9fc"),
                     Content = new Label().Text("XXX")
                 }.Size(250, 100),
                 new Label { Padding = 8, Margin = 8 }.Text("Text Two").SetStyle("BlueLabel"),
                 new ActivityIndicator()  { Color = Colors.Crimson }
                    .Bind(IsVisibleProperty, nameof(DemoOneViewModel.Loading))
                    .Bind(ActivityIndicator.IsRunningProperty, nameof(DemoOneViewModel.Loading)),
                 new ScrollView {
                     HeightRequest = 300,
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
                                
                                new StackLayout() {
                                    Children = {
                                        new Label()
                                        .Bind(Label.TextProperty, nameof(DemoDto.First))
                                        .TextColor(Colors.Fuchsia),
                                        new Label()
                                        .Bind(Label.TextProperty, nameof(DemoDto.Third))
                                        .TextColor(Colors.Aquamarine),
                                    }
                                }.Row(FrameRow.First).Column(FrameColumn.First),
                                new Label { Padding = 1, Margin = 2 }
                                    .Bind(Label.TextProperty, nameof(DemoDto.Second))
                                    .Row(FrameRow.Second)
                                    .Column(FrameColumn.First)
                                    .DynamicResources((Label.StyleProperty, "BlueLabel")),
                                new Button().Bind(Button.TextProperty, nameof(DemoDto.Third))
                                    .Row(FrameRow.Second).Column(FrameColumn.Second)
                                    .RowSpan(2)
                         }
                     }
                     ))
                     
                 }
            }
        };

protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.GetItemsCommand.Execute(null);
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
        // OPTION: Items.Clear();
        await Task.Delay(2500);
        Loading = false;
        foreach (var item in NewItems) _items.Add(item);
    }
}

internal record DemoDto(string First, string Second, string Third = "Default");
