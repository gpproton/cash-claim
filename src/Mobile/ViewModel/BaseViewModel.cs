namespace XClaim.Mobile.ViewModel;

[INotifyPropertyChanged]
public abstract partial class BaseViewModel {
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title;
}
