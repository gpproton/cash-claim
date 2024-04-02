using SQLite;

namespace XClaim.Mobile.Models;

public abstract class BaseModel {

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}