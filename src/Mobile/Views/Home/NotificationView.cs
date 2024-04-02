using Microsoft.Maui.Controls.Shapes;
using XClaim.Common.Enums;

namespace XClaim.Mobile.Views.Home;

public record AlertItem(Guid Id, string Title, string Description, DateTime Time, EventType Type = EventType.Claim);

public class NotificationView : BaseView<NotificationViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public NotificationView(NotificationViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Trash,
                Color = AppColors.Primary,
                Size = 22
            }
        }.Bind(MenuItem.CommandProperty, nameof(NotificationViewModel.ClearCommand))
        );
        Build();
    }

    protected override void Build() {
        Title = "Notifications";
        Content = new Grid {
            Padding = 4,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Star)
            ),
            Children = {
                new RefreshView {
                        Content = new CollectionView() {
                                SelectionMode = SelectionMode.None,
                                EmptyView = AppConst.EmptyListText
                            }.Bind(ItemsView.ItemsSourceProperty, nameof(NotificationViewModel.Items))
                            .ItemTemplate(new DataTemplate(() => new Grid {
                                ColumnDefinitions = Columns.Define(
                                    (SectionLevel.First, Star),
                                    (SectionLevel.Second, Auto)
                                ),
                                RowDefinitions = Rows.Define(
                                    (SectionLevel.First, Auto),
                                    (SectionLevel.Second, Auto),
                                    (SectionLevel.Third, 1)
                                ),
                                Children = {
                                    new Label { TextColor = Color.FromRgba("#7F7F7F") }
                                        .Font(size: 14)
                                        .Bind(Label.TextProperty, nameof(AlertItem.Title))
                                        .Row(SectionLevel.First)
                                        .Column(SectionLevel.First),
                                    new HorizontalStackLayout {
                                            Spacing = 6,
                                            Children = {
                                                new Label()
                                                    .Font(size: 11)
                                                    .TextColor(Colors.DodgerBlue)
                                                    .Bind(Label.TextProperty, nameof(AlertItem.Type)),
                                                new Rectangle()
                                                    .Size(4, 2)
                                                    .Center()
                                                    .BackgroundColor(Colors.Grey),
                                                new Label { TextColor = Colors.Gray }
                                                    .Font(size: 11)
                                                    .Bind(Label.TextProperty, nameof(AlertItem.Description))
                                            }
                                        }
                                        .Row(SectionLevel.Second)
                                        .Column(SectionLevel.First),
                                    new Label()
                                        .Font(size: 11)
                                        .Bind(Label.TextProperty, nameof(AlertItem.Time),
                                            convert: (DateTime value) => value.ToString("dd-MM-yy HH:mm"))
                                        .Row(SectionLevel.First)
                                        .Column(SectionLevel.Second),
                                    new BoxView()
                                        .Style(SharedStyle.HorizontalLine)
                                        .Margin(1)
                                        .Row(SectionLevel.Third)
                                        .ColumnSpan(2)
                                }
                            }.Padding(4)))
                    }.Bind(RefreshView.CommandProperty, nameof(NotificationViewModel.RefreshItemsCommand))
                    .Bind(RefreshView.IsRefreshingProperty, nameof(NotificationViewModel.IsRefreshing))
                    .Row(SectionLevel.Second)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadCommand.Execute(null);
    }
}

public partial class NotificationViewModel : ListViewModel {
    [ObservableProperty] private ObservableCollection<AlertItem> _items;

    [RelayCommand]
    private void Clear() {
        Items.Clear();
    }

    [RelayCommand]
    private async Task Load() {
        await Task.Delay(100);
        Items = new ObservableCollection<AlertItem>() {
            new(Guid.NewGuid(), "Sample Notification 1", "Test 0", DateTime.Now, EventType.Review),
            new(Guid.NewGuid(), "Sample Notification 2", "Test 1", DateTime.Now, EventType.Review)
        };
    }
}