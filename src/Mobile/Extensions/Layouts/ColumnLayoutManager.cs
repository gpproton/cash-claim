using Microsoft.Maui.Layouts;

namespace XClaim.Mobile.Extensions.Layouts;

public class ColumnLayoutManager : ILayoutManager {
    readonly ColumnLayout _columnLayout;
    IGridLayout? _gridLayout;
    GridLayoutManager? _manager;

    public ColumnLayoutManager(ColumnLayout layout) => _columnLayout = layout;

    IGridLayout ToColumnGrid(VerticalStackLayout stackLayout) {
        Grid grid = new LayoutGrid {
            ColumnDefinitions = new ColumnDefinitionCollection {
                new ColumnDefinition {
                    Width = GridLength.Star
                }
            },
            RowDefinitions = new RowDefinitionCollection()
        };

        for (int n = 0; n < stackLayout.Count; n++) {
            var child = stackLayout[n];
            if (_columnLayout.GetFill(child))
                grid.RowDefinitions.Add(new RowDefinition {
                    Height = GridLength.Star
                });
            else
                grid.RowDefinitions.Add(new RowDefinition {
                    Height = GridLength.Auto
                });

            grid.Add(child);
            grid.SetRow(child, n);
        }

        return grid;
    }

    public Size Measure(double widthConstraint, double heightConstraint) {
        _gridLayout?.Clear();
        _gridLayout = ToColumnGrid(_columnLayout);
        _manager = new GridLayoutManager(_gridLayout);

        return _manager.Measure(widthConstraint, heightConstraint);
    }

    public Size ArrangeChildren(Rect bounds) => _manager?.ArrangeChildren(bounds) ?? Size.Zero;

    class LayoutGrid : Grid {
        protected override void OnChildAdded(Element child) { }

        protected override void OnChildRemoved(Element child, int oldLogicalIndex) { }
    }
}
