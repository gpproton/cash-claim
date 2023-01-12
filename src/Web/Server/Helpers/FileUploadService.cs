using Microsoft.Net.Http.Headers;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Helpers;

public class FileUploadService {
    private readonly IConfiguration _config;

    public FileUploadService(IConfiguration config) {
        _config = config;
    }

    public static string StaticFolderName { get; set; } = "StaticFiles";

    public async Task<List<FileResponse>> UploadFiles(IFormFileCollection files) {
        List<FileResponse> uploads = new();

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
            uploads.Add(new FileResponse(fileName, filePath, extension));
        }

        return uploads;
    }

    private static string GetDatePath() => Path.Combine(DateTime.UtcNow.ToString("yyyy"), DateTime.UtcNow.ToString("MMMM"), DateTime.UtcNow.ToString("dd"));

    public string GetUploadFullPath() => Path.Combine(GetUploadRootPath(), GetDatePath());

    public string GetUploadRootPath() {
        var filesUploadPath = _config.GetValue<string>("UploadPath");

        return filesUploadPath ?? Path.Combine(Directory.GetCurrentDirectory(), StaticFolderName);
    }
}