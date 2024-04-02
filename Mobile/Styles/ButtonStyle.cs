namespace CashClaim.Mobile.Styles;

public static class ButtonStyle {
    public static Style<Button> Large = new Style<Button>()
        .Add(Button.FontSizeProperty, 16)
        .Add(Button.PaddingProperty, new Thickness(0, 16, 0, 16))
        .Add(Button.MarginProperty, new Thickness(24, 0, 24, 0));

    public static Style<Button> LargePrimary = new Style<Button>()
        .BasedOn(Large)
        .AddAppThemeBinding(Button.TextColorProperty, AppColors.Tertiary, AppColors.Primary)
        .AddAppThemeBinding(Button.BackgroundColorProperty, AppColors.Primary, AppColors.Tertiary);

    public static Style<Button> LargeLight = new Style<Button>()
       .BasedOn(Large)
       .Add(Button.BackgroundColorProperty, AppColors.Tertiary)
        .Add(Button.TextColorProperty, AppColors.Primary);

    public static Style<Button> LargeOutline = new Style<Button>()
        .Add(Button.FontSizeProperty, 16)
        .Add(Button.BackgroundColorProperty, Colors.Transparent)
        .Add(Button.BorderColorProperty, AppColors.Tertiary)
        .Add(Button.TextColorProperty, AppColors.Tertiary)
        .Add(Button.BorderWidthProperty, 1)
        .Add(Button.PaddingProperty, new Thickness(48, 16, 48, 16))
        .Add(Button.MarginProperty, new Thickness(24, 16, 24, 8));
}