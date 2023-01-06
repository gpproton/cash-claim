namespace XClaim.Common.Dtos;

public record TeamDto {
    public TeamDto(string name, CompanyDto? company, UserDto? manager) {
        Name = name;
        Company = company;
        Manager = manager;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Name { get; set; } = string.Empty;
    public CompanyDto? Company { get; set; }
    public UserDto? Manager { get; set; }
}