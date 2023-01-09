using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class TeamResponse : BaseResponse {
    public TeamResponse(string name, CompanyResponse? company, UserResponse? manager) {
        Name = name;
        Company = company;
        Manager = manager;
    }

    public string Name { get; set; }
    public CompanyResponse? Company { get; set; }
    public UserResponse? Manager { get; set; }
}