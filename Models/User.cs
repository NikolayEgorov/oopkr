namespace Models;

public class User : Base
{
    public string name { get; set; } = String.Empty;
    public string surname { get; set; } = String.Empty;
    public string email { get; set; } = String.Empty;
    public string password { get; set; } = String.Empty;

    public User() {}
    public string GetFullName()
    {
        return this.name + " " + this.surname;
    }
}