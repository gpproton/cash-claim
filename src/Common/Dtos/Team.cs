using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class Team : BaseResponse {
    public Team(string name, Company? company, User? manager) {
        Name = name;
        Company = company;
        Manager = manager;
    }

    public string Name { get; set; }
    public Company? Company { get; set; }
    public User? Manager { get; set; }
}