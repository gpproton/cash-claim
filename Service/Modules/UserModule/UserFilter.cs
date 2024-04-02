using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.UserModule;

public sealed class UserFilter : GenericFilter {
    [CompareTo(nameof(UserEntity.FirstName), nameof(UserEntity.LastName), nameof(UserEntity.Email), CombineWith = CombineType.Or)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}