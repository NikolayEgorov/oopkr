namespace Models;

using Repositories;

public class Boller : Base
{
    private readonly DatabaseContext? _db = null;

    public string title { get; set; } = string.Empty;
    public int currentPower { get; set; } = 0;
    public int generatePower { get; set; } = 0;
    public int consumptionPower { get; set; } = 0;

    public List<PlantBoller> plantBollers { get; } = new List<PlantBoller>();
    public List<Plant> plants { get; set; } = new List<Plant>();

    public Boller() {}
    public Boller(DatabaseContext databaseContext): base(databaseContext) {}
}