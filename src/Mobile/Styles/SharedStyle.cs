namespace XClaim.Mobile.Styles;

public static class SharedStyle {
    public static Style<BoxView> HorizontalLine = new Style<BoxView>()
        .Add(BoxView.HeightRequestProperty, 0.8)
        .Add(BoxView.HorizontalOptionsProperty, LayoutOptions.Fill)
        .Add(BoxView.MarginProperty, new Thickness(8, 0, 8, 0))
        .AddAppThemeBinding(BoxView.ColorProperty, AppColors.Gray300, AppColors.Tertiary);
}