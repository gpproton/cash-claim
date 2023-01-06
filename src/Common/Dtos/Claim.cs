using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record Claim {
    public Claim(string description, string notes, decimal amount, Category? category, Company? company, ClaimStatus status, User? owner, ICollection<FileDto>? files) {
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
    public Category? Category { get; set; }
    public Company? Company { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public User? Owner { get; set; }
    public ICollection<FileDto>? Files { get; set; }
}