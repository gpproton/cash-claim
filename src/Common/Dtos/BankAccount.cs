using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class BankAccount : BaseResponse {
    public BankAccount(string? fullName, BankResponse? bank, User? owner, string? number, string? description) {
        FullName = fullName;
        Bank = bank;
        Owner = owner;
        Number = number;
        Description = description;
    }

    public string? FullName { get; set; }
    public BankResponse? Bank { get; set; }
    public User? Owner { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }
}