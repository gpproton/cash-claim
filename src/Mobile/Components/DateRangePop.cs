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
        Content = new VerticalStackLayout {
            Padding = 8,
            Spacing = 5,
            MinimumHeightRequest = 150,
            HorizontalOptions = LayoutOptions.Fill,
            Children = {
                new Label { TextColor = AppColors.Primary }.Text("Select date range")
                    .Font(size: 18)
                    .CenterHorizontal()
                    .Margins(0, 4, 0, 4),

                new DatePickerField { TextColor = AppColors.Primary, Title = "Start Date", Format = "yyyy-MMMM-dd", AllowClear = false }
                    .Bind(DatePickerField.DateProperty, nameof(StartDate), source: this, mode: BindingMode.TwoWay)
                    .Margins(0, 8, 0, 0)
                    .FillHorizontal(),

                new DatePickerField { TextColor = AppColors.Primary, Title = "End Date", Format = "yyyy-MMMM-dd", AllowClear = false }
                    .Bind(DatePickerField.DateProperty, nameof(EndDate), source: this, mode: BindingMode.TwoWay)
                    .Margins(0, 8, 0, 0)
                    .FillHorizontal()
            }
        };
    }
}