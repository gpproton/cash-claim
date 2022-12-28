#nullable enable
using Microsoft.Maui.Layouts;

namespace XClaim.Mobile.Extensions.Layouts;

public class ColumnLayoutManager : ILayoutManager {
    private readonly ColumnLayout _columnLayout;
    private IGridLayout? _gridLayout;
    private GridLayoutManager? _manager;

    public ColumnLayoutManager(ColumnLayout layout) {
        _columnLayout = layout;
    }

    private IGridLayout ToColumnGrid(VerticalStackLayout stackLayout) {
        Grid grid = new LayoutGrid {
            ColumnDefinitions = new ColumnDefinitionCollection {
                new() {
                    Width = GridLength.Star
                }
            },
            RowDefinitions = new RowDefinitionCollection()
        };

        for (var n = 0; n < stackLayout.Count; n++) {
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

    public Size ArrangeChildren(Rect bounds) {
        return _manager?.ArrangeChildren(bounds) ?? Size.Zero;
    }

    private class LayoutGrid : Grid {
        protected override void OnChildAdded(Element child) { }

        protected override void OnChildRemoved(Element child, int oldLogicalIndex) { }
    }
}