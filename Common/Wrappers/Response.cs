namespace CashClaim.Common.Wrappers;

public class Response<T> {
    public Response() { }

    public Response(T? data) {
        Errors = null;
        Data = data;
    }

    public T? Data { get; set; }
    public bool Succeeded { get; set; }
    public string[]? Errors { get; set; }
    public string Message { get; set; } = String.Empty;
}