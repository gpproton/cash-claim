using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public record Team : BaseResponse {
    public Team(string name, Company? company, User? manager) {
        Name = name;
        Company = company;
        Manager = manager;
    }

    public string Name { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public User? Manager { get; set; }
}