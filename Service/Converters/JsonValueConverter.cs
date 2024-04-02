using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace CashClaim.Service.Converters;

public class JsonValueConverter<T> : ValueConverter<T, string> {
    public JsonValueConverter() : base(v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<T>(v) ?? (T) new object()) { }
}