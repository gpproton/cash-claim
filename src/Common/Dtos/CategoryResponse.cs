using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class CategoryResponse : BaseResponse {
    public CategoryResponse(string? name, CompanyResponse? company, string? description, string? icon) {
        Name = name;
        Company = company;
        Description = description;
        Icon = icon;
    }

    public string? Name { get; set; }
    public CompanyResponse? Company { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}