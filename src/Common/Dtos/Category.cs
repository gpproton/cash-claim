using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class Category : BaseResponse {
    public Category(string? name, Company? company, string? description, string? icon) {
        Name = name;
        Company = company;
        Description = description;
        Icon = icon;
    }

    public string? Name { get; set; }
    public Company? Company { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}