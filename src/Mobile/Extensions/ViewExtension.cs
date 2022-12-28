namespace XClaim.Mobile.Extensions;

public static class ViewExtension {
    public static View SetStyle(this View view, string styleName) {
        if (Application.Current != null) view.Style = (Style)Application.Current.Resources[styleName];

        return view;
    }
}