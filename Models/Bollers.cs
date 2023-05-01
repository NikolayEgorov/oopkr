namespace Models;

public class Boller : Base
{
    public bool inWork { get; set; } = false;
    public int generatePower { get; set; } = 0;
    public int consumptionPower { get; set; } = 0;

    public Boller() {}
}