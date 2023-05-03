namespace Models;

public class User : Base
{
    public string name { get; set; } = String.Empty;
    public string surname { get; set; } = String.Empty;
    public string email { get; set; } = String.Empty;
    public string password { get; set; } = String.Empty;
    public int status { get; set; } = 0;

    public User() {}
    public static User CreateAdmin()
    {
        User user = new User();

        user.status = 1;
        user.name = "admin";
        user.surname = "admin";
        user.password = "123456";
        user.email = "admin@kr-system.com";

        return user;
    }

    public string GetFullName()
    {
        return this.name + " " + this.surname;
    }
}