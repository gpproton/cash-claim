namespace XClaim.Mobile.Styles;

public static class ButtonStyle {
    public static Style<Button> LargePrimary = new Style<Button>()
        .Add(Button.FontSizeProperty, 16)
        .Add(Button.PaddingProperty, new Thickness(0, 16, 0, 16))
        .Add(Button.MarginProperty, new Thickness(24, 0, 24, 0))
        .AddAppThemeBinding(Button.TextColorProperty, AppColors.Tertiary, AppColors.Primary)
        .AddAppThemeBinding(Button.BackgroundColorProperty, AppColors.Primary, AppColors.Tertiary);
}