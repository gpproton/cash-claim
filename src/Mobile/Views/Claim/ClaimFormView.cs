namespace XClaim.Mobile.Views.Claim;

public class ClaimFormView : BaseView<ClaimFormViewModel> {
    enum SectionLevel { First, Second, Third }

    public ClaimFormView(ClaimFormViewModel vm) : base(vm) => Build();

    protected override void Build() {
        Title = "New Claim Request";
        Content = new VerticalStackLayout {
            Spacing = 10,
            Children = {
                new TextField { Title = "Description" },
                new TextField { Title = "Amount", Keyboard = Keyboard.Numeric },
                new PickerField { Title = "Category", AllowClear =  false }
                .Bind(PickerField.ItemsSourceProperty, nameof(ClaimFormViewModel.Categories)),
                new PickerField { Title = "Account", AllowClear =  false }
                .Bind(PickerField.ItemsSourceProperty, nameof(ClaimFormViewModel.Accounts)),

                new Frame {
                    Padding = 10,
                    Content = new Grid {
                        ColumnDefinitions = Columns.Define(
                            (SectionLevel.First, Star),
                            (SectionLevel.Second, Auto)
                        ),
                        Children = {
                            new ScrollView {
                                FlowDirection = FlowDirection.LeftToRight,
                                Content = new Grid { }
                            }.Column(SectionLevel.First),
                            new Grid {
                                RowDefinitions = Rows.Define(
                                    (SectionLevel.First, Auto),
                                    (SectionLevel.Second, Auto)
                                ),
                                Children = {
                                     new AvatarView() {
                                         CornerRadius = 8,
                                         Margin = 4,
                                         Content = new Image().Source(new FontImageSource() {
                                            FontFamily = "FASolid",
                                            Glyph = FA.Solid.Camera,
                                            Color = Colors.White
                                        }).Size(24)
                                    }.BackgroundColor(Colors.OrangeRed)
                                    .Size(48, 48).Row(SectionLevel.First)
                                    .TapGesture(() => TakePhoto()),
                                    new AvatarView() {
                                        CornerRadius = 8,
                                        Margin = 4,
                                        Content = new Image().Source(new FontImageSource() {
                                            FontFamily = "FASolid",
                                            Glyph = FA.Solid.File,
                                            Color = Colors.White
                                        }).Size(24)
                                    }.BackgroundColor(Colors.DodgerBlue)
                                    .Size(48, 48).Row(SectionLevel.Second)
                                    .TapGesture(() => PickFiles())
                                }
                            }.CenterVertical()
                            .Margins(8, 8, 8, 8)
                            .Column(SectionLevel.Second)
                        }
                    }.Height(100)
                },

                new Editor { Placeholder = "Notes" }
                .Height(160),
                new Button().Text("Submit")
                .DynamicResource(StyleProperty, "ButtonLargePrimary")
                .CenterVertical()
                .Margins(0, 16, 0, 0)
            }
        }.CenterHorizontal().FillHorizontal()
        .Paddings(0, 8, 0, 0)
        .Margins(8, 0, 8, 0);
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadOptionsCommand.Execute(null);
    }

    private async void TakePhoto() {
        if (MediaPicker.Default.IsCaptureSupported) {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null) {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }

    
    private async void PickFiles() {
        /*
        SAMPLE: Sample mime type selection.

        var customFileTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>> {
                    { DevicePlatform.iOS, new[] { "com.adobe.pdf" } },
                    { DevicePlatform.Android, new[] { "application/pdf", "image/jpeg", "image/png" } },
                    { DevicePlatform.WinUI, new[] { ".pdf", , ".jpg", ".jpeg", ".png"} },
                    { DevicePlatform.macOS, new[] { "pdf", "jpg", "jpeg", "png" } }
                }
            );
        var options = new PickOptions {
            PickerTitle = "Select claim documents.",
            FileTypes = customFileTypes
        };

        */

        var results = await FilePicker.PickMultipleAsync();
        if (results != null && results.Any()) {
            foreach (var result in results) {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)) {
                    var stream = await result.OpenReadAsync();
                    var Image = ImageSource.FromStream(() => stream);
                    BindingContext.ImageFiles.Add(Image);
                }
                var copyPath = Path.Combine(FileSystem.CacheDirectory, result.FileName);
                BindingContext.FilePaths.Add(copyPath);
                using (var destination = File.Create(copyPath))
                using (var source = await result.OpenReadAsync())
                    await source.CopyToAsync(destination);
            }
        }
    }
}

public partial class ClaimFormViewModel : BaseViewModel {
    [ObservableProperty]
    private ObservableCollection<string> _accounts;
    [ObservableProperty]
    private ObservableCollection<string> _categories;
    [ObservableProperty]
    private ObservableCollection<ImageSource> _imageFiles;
    [ObservableProperty]
    private ObservableCollection<string> _filePaths;


    [RelayCommand]
    private void LoadOptions() {
        Accounts = new ObservableCollection<string>() { "GT Bank", "Zenith", "Union Bank" };
        Categories = new ObservableCollection<string>() { "Fuel", "Transport", "Internet" };
        ImageFiles = new();
        FilePaths = new();
    }

    
}
