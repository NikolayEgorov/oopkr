namespace Models;

public class Plant : Base
{
    public string name { get; set; } = String.Empty;
    public List<Boller> bollers { get; set; } = new List<Boller>();

    public Plant() {}
}