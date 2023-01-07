using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public record Category : BaseResponse {
    public Category(string? name, Company? company, string? description, string? icon) {
        Name = name;
        Company = company;
        Description = description;
        Icon = icon;
    }

    public string? Name { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}