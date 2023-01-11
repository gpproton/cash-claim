namespace XClaim.Common.Dtos;

public class AuthResponse {
    public AuthResponse(
        bool valid,
        DateTime? expiryTimeStamp,
        int expiresIn,
        string? token = null,
        string message = "Un-authorized access",
        string userName = default!,
        string role = default!,
        ProfileResponse? Data = null
        ) {
        Valid = valid;
        ExpiryTimeStamp = expiryTimeStamp;
        ExpiresIn = expiresIn;
        Token = token;
        Message = message;
        UserName = userName;
        Role = role;
    }

    public bool Valid { get; set; }
    public DateTime? ExpiryTimeStamp { get; set; }
    public int ExpiresIn { get; set; }
    public string? Token { get; set; }
    public string Message { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}