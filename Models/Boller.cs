namespace Models;

public class Boller : Base
{
    public string title { get; set; } = string.Empty;
    public int currentPower { get; set; } = 0;
    public int generatePower { get; set; } = 0;
    public int consumptionPower { get; set; } = 0;

    public List<PlantBoller> plantBollers { get; } = new List<PlantBoller>();
    public List<Plant> plants { get; set; } = new List<Plant>();

    public Boller() {}
}