namespace XClaim.Common.Dtos;

public record Team {
    public Team(string name, Company? company, UserDto? manager) {
        Name = name;
        Company = company;
        Manager = manager;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Name { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public UserDto? Manager { get; set; }
}