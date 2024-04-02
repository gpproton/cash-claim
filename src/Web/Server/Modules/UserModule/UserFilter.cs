using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.UserModule;

public sealed class UserFilter : GenericFilter {
    [CompareTo(nameof(UserEntity.FirstName), nameof(UserEntity.LastName), nameof(UserEntity.Email), CombineWith = CombineType.Or)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}