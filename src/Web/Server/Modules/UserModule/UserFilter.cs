using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserFilter : GenericFilter {
    [CompareTo("FirstName","LastName", "Email", CombineWith = CombineType.Or)]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Search { get; set; }
}