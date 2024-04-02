using Microsoft.Maui.Controls.Shapes;

namespace CashClaim.Mobile.Styles;

public static class SharedStyle {
    public static Style<BoxView> HorizontalLine = new Style<BoxView>()
        .AddAppThemeBinding(BoxView.ColorProperty, AppColors.Gray300, AppColors.Tertiary)
        .Add(BoxView.HeightRequestProperty, 0.8)
        .Add(BoxView.HorizontalOptionsProperty, LayoutOptions.Fill)
        .Add(BoxView.MarginProperty, new Thickness(8, 0, 8, 0));

    public static Style<Border> BoxFormField = new Style<Border>()
       .AddAppThemeBinding(Border.StrokeProperty, AppColors.Secondary, AppColors.Tertiary)
       .Add(Border.StrokeThicknessProperty, 1)
       .Add(Border.BackgroundColorProperty, Colors.Transparent)
       .Add(Border.PaddingProperty, new Thickness(18, 2))
       .Add(Border.HeightRequestProperty, 48)
       .Add(Border.StrokeShapeProperty, new RoundRectangle {
           CornerRadius = new CornerRadius(6)
       });
}