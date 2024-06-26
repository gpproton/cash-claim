namespace CashClaim.Mobile.Views.Profile;

public class SettingView : BaseView<SettingViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public SettingView(SettingViewModel vm) : base(vm) {
        Build();
    }

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
                            new TextField { Title = "Phone", Keyboard = Keyboard.Telephone }
                            // TODO: Microsoft account indication
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
}

public partial class SettingViewModel : BaseViewModel { }