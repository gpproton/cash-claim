namespace XClaim.Mobile.Views.Profile;

public class SettingView : BaseView<SettingViewModel> {

    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public SettingView(SettingViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "Profile Setting";
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
                        new TextField { Title = "Full Name" },
                        new TextField { Title = "Email", Keyboard = Keyboard.Email },
                        new TextField { Title = "Phone", Keyboard = Keyboard.Telephone },
                        // Micrissft account indication
                        //new PickerField { Title = "Type", AllowClear = false }
                        //.Bind(PickerField.ItemsSourceProperty, nameof(BankViewModel.Types))
                    }
                }.CenterHorizontal()
                .FillHorizontal()
                .Row(SectionLevel.First),
                 new Button().Text("Save")
                    .DynamicResource(StyleProperty, "ButtonLargePrimary")
                    .CenterVertical()
                    .Row(SectionLevel.Second)
            }
        };
    }
}

public partial class SettingViewModel : BaseViewModel { }