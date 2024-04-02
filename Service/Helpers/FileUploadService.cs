using Microsoft.Net.Http.Headers;
using CashClaim.Common.Dtos;

namespace XClaim.Web.Server.Helpers;

public class FileUploadService {
    private readonly IConfiguration _config;

    public FileUploadService(IConfiguration config) {
        _config = config;
    }

    private static string StaticFolderName { get; set; } = "static-files";

    public async Task<List<FileResponse>> UploadFiles(IEnumerable<IFormFile> files) {
        List<FileResponse> uploads = new List<FileResponse>();

        var storePath = GetUploadFullPath();
        foreach (var file in files) {
            if (file.Length <= 0) continue;
            var extension = Path.GetExtension(file.FileName);
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().ToString();
            var saveName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(GetDatePath(), saveName);

            if (!Directory.Exists(storePath)) Directory.CreateDirectory(storePath);
            var savePath = Path.Combine(storePath, saveName);
            await using var stream = File.Create(savePath);
            await file.CopyToAsync(stream);
            var response = new FileResponse {
                Name = fileName,
                Path = filePath,
                Extension = extension
            };
            uploads.Add(response);
        }

        return uploads;
    }

    private static string GetDatePath() => Path.Combine(DateTime.UtcNow.ToString("yyyy"), DateTime.UtcNow.ToString("MMMM"), DateTime.UtcNow.ToString("dd"));

    private string GetUploadFullPath() => Path.Combine(GetUploadRootPath(), GetDatePath());

    public string GetUploadRootPath() {
        var filesUploadPath = _config.GetValue<string>("UploadPath");

        return filesUploadPath ?? Path.Combine(Directory.GetCurrentDirectory(), StaticFolderName);
    }
}