using Microsoft.Maui.Controls.Shapes;

namespace XClaim.Mobile.Views.Claim;

public class ClaimFormView : BaseView<ClaimFormViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third
    }

    public ClaimFormView(ClaimFormViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.EllipsisVertical,
                Size = 20
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Build();
    }

    protected override void Build() {
        Title = "New Claim Request";
        Content = new VerticalStackLayout {
                Spacing = 10,
                Padding = 8,
                Children = {
                    new TextField { Title = "Description" },
                    new TextField { Title = "Amount", Keyboard = Keyboard.Numeric },
                    new PickerField { Title = "Category", AllowClear = false }
                        .Bind(PickerField.ItemsSourceProperty, nameof(ClaimFormViewModel.Categories)),
                    new PickerField { Title = "Account", AllowClear = false }
                        .Bind(PickerField.ItemsSourceProperty, nameof(ClaimFormViewModel.Accounts)),

                    new Frame {
                        Padding = 10,
                        Content = new Grid {
                            HeightRequest = 135,
                            ColumnDefinitions = Columns.Define(
                                (SectionLevel.First, Star),
                                (SectionLevel.Second, Auto)
                            ),
                            RowDefinitions = Rows.Define(
                                (SectionLevel.First, Auto),
                                (SectionLevel.Second, Star),
                                (SectionLevel.Third, Auto)
                            ),
                            Children = {
                                new HorizontalStackLayout {
                                    new Image().Source(new FontImageSource() {
                                        FontFamily = "FASolid",
                                        Glyph = FA.Solid.Paperclip,
                                        Color = Colors.Gray
                                    }).Size(18)
                                    .Margins(0, 0, 8, 0),
                                    new Label().Text("Attachements").Font(size: 14)
                                }.Row(SectionLevel.First),
                                new CollectionView {
                                    Margin = 2,
                                    ItemsLayout = LinearItemsLayout.Horizontal,
                                    VerticalOptions = LayoutOptions.Fill,
                                    HorizontalOptions = LayoutOptions.Fill,
                                    MinimumHeightRequest = 72,
                                }.Bind(ItemsView.ItemsSourceProperty, nameof(ClaimFormViewModel.ImageFiles))
                                .ItemTemplate(new DataTemplate(() =>
                                    new StackLayout {
                                        new Frame {
                                            CornerRadius = 8,
                                            Padding = 0,
                                            IsClippedToBounds = true,
                                            Content = new Image().Center()
                                            .Bind(Image.SourceProperty, ".").Size(128)
                                        }.Size(72)
                                    }.Padding(2)
                                ))
                                .Row(SectionLevel.Second),
                                new HorizontalStackLayout {
                                    Spacing = 10,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children = {
                                        new Button() {
                                            CornerRadius = 8,
                                            WidthRequest = 48,
                                            HeightRequest = 32,
                                            BackgroundColor = Colors.Gray,
                                            ImageSource = new FontImageSource {
                                                FontFamily = "FASolid",
                                                Glyph = FA.Solid.Camera,
                                                Color = Colors.White,
                                                Size = 16
                                            }
                                        }.Invoke(i => i.Clicked += (sender, args) => TakePhoto()),
                                        new Button() {
                                            CornerRadius = 8,
                                            WidthRequest = 48,
                                            HeightRequest = 32,
                                            BackgroundColor = Colors.DodgerBlue,
                                            ImageSource = new FontImageSource {
                                                FontFamily = "FASolid",
                                                Glyph = FA.Solid.File,
                                                Color = Colors.White,
                                                Size = 16
                                            }
                                        }.Invoke(i => i.Clicked += (sender, args) => PickFiles())
                                    }
                                }.Row(SectionLevel.Third)
                            }
                        }
                    },

                    new Editor { Placeholder = "Notes" }
                        .Height(120),
                    new Button().Text("Save")
                        .DynamicResource(StyleProperty, "ButtonLargePrimary")
                        .CenterVertical()
                        .Margins(0, 16, 0, 0)
                }
            }.CenterHorizontal().FillHorizontal();
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadOptionsCommand.Execute(null);
    }

    private async void TakePhoto() {
        if (MediaPicker.Default.IsCaptureSupported) {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null) {
                var localFilePath = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using var sourceStream = await photo.OpenReadAsync();
                using var localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
                BindingContext.ImageFiles.Add(localFilePath);
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
        if (results != null && results.Any())
            foreach (var result in results) {
                var copyPath = System.IO.Path.Combine(FileSystem.CacheDirectory, result.FileName);
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)) {
                    var stream = await result.OpenReadAsync();
                    var Image = ImageSource.FromStream(() => stream);
                    BindingContext.ImageFiles.Add(copyPath);
                } else
                    BindingContext.FilePaths.Add(copyPath);

                using (var destination = File.Create(copyPath))
                using (var source = await result.OpenReadAsync()) {
                    await source.CopyToAsync(destination);
                }
            }
    }
}

public partial class ClaimFormViewModel : BaseViewModel {
    [ObservableProperty] private ObservableCollection<string> _accounts;
    [ObservableProperty] private ObservableCollection<string> _categories;
    [ObservableProperty] private ObservableCollection<string> _imageFiles;
    [ObservableProperty] private ObservableCollection<string> _filePaths;


    [RelayCommand]
    private void LoadOptions() {
        Accounts = new ObservableCollection<string>() { "GT Bank", "Zenith", "Union Bank" };
        Categories = new ObservableCollection<string>() { "Fuel", "Transport", "Internet" };
        ImageFiles = new();
        FilePaths = new();
    }
}