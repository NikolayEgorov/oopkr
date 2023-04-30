namespace Models;

public class User : Base
{
    public string name { get; set; } = String.Empty;
    public string surname { get; set; } = String.Empty;
    public List<Order> orders { get; set; } = new List<Order>();
    public string GetFullName()
    {
        return this.name + " " + this.surname;
    }
}