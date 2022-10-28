namespace XClaim.Mobile.Extensions;

public static class ViewExtension {
    public static View SetStyle(this View view, string StyleName) {
        view.Style = (Style)Application.Current.Resources[StyleName];

        return view;
    }
}
