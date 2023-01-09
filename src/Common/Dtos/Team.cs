using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class Team : BaseResponse {
    public Team(string name, CompanyResponse? company, User? manager) {
        Name = name;
        Company = company;
        Manager = manager;
    }

    public string Name { get; set; }
    public CompanyResponse? Company { get; set; }
    public User? Manager { get; set; }
}