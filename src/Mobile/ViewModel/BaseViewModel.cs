namespace XClaim.Mobile.ViewModel;

[INotifyPropertyChanged]
public abstract partial class BaseViewModel {
    [ObservableProperty]
    public bool _isBusy;

    [ObservableProperty]
    public string _title;
}
