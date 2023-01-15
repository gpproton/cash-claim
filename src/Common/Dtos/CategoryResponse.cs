using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class CategoryResponse : BaseResponse {
    public string Name { get; set; } = string.Empty;
    public CompanyResponse? Company { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string Icon { get; set; } = string.Empty;
}