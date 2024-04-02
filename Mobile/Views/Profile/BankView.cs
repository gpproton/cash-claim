namespace CashClaim.Mobile.Views.Profile;

public class BankView : BaseView<BankViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public BankView(BankViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Title = "Bank Account";
        Content = new Grid {
            Padding = 8,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Star),
                (SectionLevel.Second, Auto)
            ),
            Children = {
                new VerticalStackLayout {
                        Spacing = 10,
                        Children = {
                            new TextField { Title = "Account Name" },
                            new TextField { Title = "Account Number", Keyboard = Keyboard.Numeric },
                            new PickerField { Title = "Bank", AllowClear = false }
                                .Bind(PickerField.ItemsSourceProperty, nameof(BankViewModel.Banks)),
                            new PickerField { Title = "Type", AllowClear = false }
                                .Bind(PickerField.ItemsSourceProperty, nameof(BankViewModel.Types)),
                            new Editor { Placeholder = "Description" }
                                .Height(120)
                        }
                    }.CenterHorizontal()
                    .FillHorizontal()
                    .Row(SectionLevel.First),
                new Button().Text("Save")
                    .Style(ButtonStyle.LargePrimary)
                    .CenterVertical()
                    .Row(SectionLevel.Second)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadCommand.Execute(null);
    }
}

public partial class BankViewModel : BaseViewModel {
    [ObservableProperty] private ObservableCollection<string> _banks;

    [ObservableProperty] private ObservableCollection<string> _types;

    [RelayCommand]
    private void Load() {
        Banks = new ObservableCollection<string>() { "GT Bank", "Zenith", "Union Bank" };
        Types = new ObservableCollection<string>() { "Savings", "Current", "Credit" };
    }
}