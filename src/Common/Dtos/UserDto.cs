using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record UserDto (string Email, string Phone, string FirstName, string LastName, decimal Balance, UserPermission Permission, bool Verified);
