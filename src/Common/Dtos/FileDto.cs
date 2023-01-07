namespace XClaim.Common.Dtos;

public record FileDto {
    public FileDto(string? name, string? path, string? extension) {
        Name = name;
        Path = path;
        Extension = extension;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Name { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
}