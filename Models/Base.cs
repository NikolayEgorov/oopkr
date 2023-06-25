namespace Models;

public class Base 
{
    private readonly DatabaseContext? _db = null;

    public int id { get; set; } = 0;

    public Base() {}
    public Base(DatabaseContext db)
    {
        this._db = db;
    }

    public DatabaseContext GetDbContext()
    {
        return this._db;
    }
}