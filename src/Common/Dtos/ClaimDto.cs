using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record ClaimDto {
    public ClaimDto(string description, string notes, decimal amount, CategoryDto? category, CompanyDto? company, ClaimStatus status, UserDto? owner, ICollection<FileDto>? files) {
        Description = description;
        Notes = notes;
        Amount = amount;
        Category = category;
        Company = company;
        Status = status;
        Owner = owner;
        Files = files;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Description { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public CategoryDto? Category { get; set; }
    public CompanyDto? Company { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public UserDto? Owner { get; set; }
    public ICollection<FileDto>? Files { get; set; }
}