namespace CashClaim.Common.Dtos;

public class AuthResponse {
    public bool Confirmed { get; set; }
    public DateTime? ExpiryTimeStamp { get; set; }
    public int ExpiresIn { get; set; }
    public string? Token { get; set; }
    public string Message { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public UserResponse? Data { get; set; }
}