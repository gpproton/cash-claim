using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

internal class DemoOneView : BaseView<DemoOneViewModel>
{
    enum FrameRow { First, Second }
    enum FrameColumn { First, Second }
    public DemoOneView(DemoOneViewModel demoViewModel) : base(demoViewModel) => Content = new VerticalStackLayout
    {
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
                 new Frame {
                    BackgroundColor = Color.FromArgb("c9a9fc"),
                    Content = new Label().Text("XXX")
                 }.Size(250, 100),
                 new Label { Padding = 16, Margin = 16 }.Text("Text Two").SetStyle("BlueLabel"),

                 new ScrollView {
                     HeightRequest = 300,
                     Content = new CollectionView {
                     ItemTemplate = new DataTemplate(() => new Grid {
                            Padding = 10,
                            RowDefinitions = Rows.Define(
                                (FrameRow.First, Auto),
                                (FrameRow.Second, Auto)
                            ),
                            ColumnDefinitions = Columns.Define(
                                (FrameColumn.First, Auto),
                                (FrameColumn.Second, Auto)
                            ),
                            Children = {
                                new Label()
                                 .Bind(Label.TextProperty, nameof(DemoItem.First))
                                 .TextColor(Colors.Fuchsia)
                                 .Row(FrameRow.First),
                                new Label { Padding = 4, Margin = 2 }
                                    .Bind(Label.TextProperty, nameof(DemoItem.Second))
                                    .Row(FrameRow.Second)
                                    .Column(FrameColumn.First)
                                    .SetStyle("BlueLabel"),
                                new Button().Bind(Button.TextProperty, nameof(DemoItem.Third))
                                    .Row(FrameRow.Second).Column(FrameColumn.Second)
                            }
                        }
                    )
                 }
                 .Bind(ItemsView.ItemsSourceProperty, nameof(DemoOneViewModel.DemoItems))
               }
            }
    };
}

internal partial class DemoOneViewModel : BaseViewModel {
    public List<DemoItem> DemoItems { get; }

    public DemoOneViewModel()
    {
        DemoItems = new()
        {
            new DemoItem("test a 1", "Test a 2"),
            new DemoItem("test b 1", "Test b 2"),
            new DemoItem("test c 1", "Test c 2"),
            new DemoItem("test d 1", "Test d 2"),
            new DemoItem("test e 1", "Test e 2"),
            new DemoItem("test e 1", "Test e 2")
        };
    }
}

internal record DemoItem(string First, string Second, string Third = "Default");
