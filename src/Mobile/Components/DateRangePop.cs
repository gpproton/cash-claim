using MauiPopup.Views;

namespace XClaim.Mobile.Components;

public partial class DateRangePop : BasePopupPage {
    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private DateTime _startDate = DateTime.Now.AddDays(-7);

    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private DateTime _endDate = DateTime.Now;

    public DateRangePop() {
        HorizontalOptions = LayoutOptions.Fill;
        VerticalOptions = LayoutOptions.End;
        BackgroundColor = Colors.Transparent;
        Content = new VerticalStackLayout {
            Padding = 8,
            Spacing = 5,
            MinimumHeightRequest = 150,
            HorizontalOptions = LayoutOptions.Fill,
            Children = {
                new Label { TextColor = AppColors.Primary }.Text(AppConst.DateTitleText)
                    .Font(size: 18)
                    .CenterHorizontal()
                    .Margins(0, 1, 0, 2),

                new DatePickerField { TextColor = AppColors.Primary, Title = AppConst.DateStartText, Format = "yyyy-MMMM-dd", AllowClear = false }
                    .Bind(DatePickerField.DateProperty, nameof(StartDate), source: this, mode: BindingMode.TwoWay)
                    .Margins(0, 8, 0, 0)
                    .FillHorizontal(),

                new DatePickerField { TextColor = AppColors.Primary, Title = AppConst.DateEndText, Format = "yyyy-MMMM-dd", AllowClear = false }
                    .Bind(DatePickerField.DateProperty, nameof(EndDate), source: this, mode: BindingMode.TwoWay)
                    .Margins(0, 8, 0, 0)
                    .FillHorizontal()
            }
        };
    }
}