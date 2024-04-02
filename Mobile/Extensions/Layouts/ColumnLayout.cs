using Microsoft.Maui.Layouts;

namespace CashClaim.Mobile.Extensions.Layouts;

public class ColumnLayout : VerticalStackLayout {
    public static readonly BindableProperty FillProperty = BindableProperty.Create("Fill", typeof(bool),
        typeof(ColumnLayout), false);

    public ColumnLayout() { }

    protected override ILayoutManager CreateLayoutManager() {
        return new ColumnLayoutManager(this);
    }

    public bool GetFill(BindableObject bindableObject) {
        return (bool)bindableObject.GetValue(FillProperty);
    }

    public void SetFill(BindableObject bindableObject, bool fill) {
        bindableObject.SetValue(FillProperty, fill);
    }

    public bool GetFill(IView view) {
        if (view is BindableObject bindableObject) return GetFill(bindableObject);

        return false;
    }
}