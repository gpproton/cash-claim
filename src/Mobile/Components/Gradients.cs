namespace XClaim.Mobile.Components;

internal static class Gradients {
    internal static LinearGradientBrush AppGradient => new() {
        StartPoint = new Point(0, 0),
        EndPoint = new Point(1, 0),
        GradientStops = {
            new GradientStop {
                Offset = 0.1F,
                Color = AppColors.Primary
            },
            new GradientStop {
                Offset = 1.0F,
                Color = AppColors.Secondary
            }
        }
    };
}