using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record Claim : BaseResponse {
    public Claim(string description, string notes, decimal amount, Category? category, Company? company, ClaimStatus status, User? owner, ICollection<FileResponse>? files) {
        Description = description;
        Notes = notes;
        Amount = amount;
        Category = category;
        Company = company;
        Status = status;
        Owner = owner;
        Files = files;
    }

    public string Description { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public Category? Category { get; set; }
    public Company? Company { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public User? Owner { get; set; }
    public User? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public User? ConfirmedBy { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public User? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public ICollection<FileResponse>? Files { get; set; }
}