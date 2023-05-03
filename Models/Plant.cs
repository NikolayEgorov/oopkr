namespace Models;

public class Plant : Base
{
    public string name { get; set; } = String.Empty;
    public string address { get; set; } = String.Empty;
    public int boillersCount { get; set; } = 0;
    public int maxGeneratePower { get; set; } = 0;
    public int maxConsumptionPower { get; set; } = 0;

    public List<Boller> bollers { get; set; } = new List<Boller>();

    public Plant() {}
}