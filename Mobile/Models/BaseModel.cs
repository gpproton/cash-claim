using SQLite;

namespace CashClaim.Mobile.Models;

public abstract class BaseModel {

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}