using XClaim.Common.Enums;

namespace XClaim.Common.Dtos; 
public record UserProfile (string FirstName, string LastName, UserPermission Permission = UserPermission.Standard, int Count = 0, decimal Balance = 0, string Department = "Main");
