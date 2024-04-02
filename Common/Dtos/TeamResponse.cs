using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class TeamResponse : BaseResponse {
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string Description { get; set; } = string.Empty;
    public CompanyResponse? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public UserResponse? Manager { get; set; }
    public Guid? ManagerId { get; set; }
}