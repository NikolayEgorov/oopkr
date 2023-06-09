namespace Models;

using Repositories;

public class Plant : Base
{
    public string name { get; set; } = String.Empty;
    public string address { get; set; } = String.Empty;
    public int boillersCount { get; set; } = 0;
    public int maxGeneratePower { get; set; } = 0;
    public int maxConsumptionPower { get; set; } = 0;


    public List<PlantBoller> plantBollers { get; } = new List<PlantBoller>();
    public List<Boller> bollers { get; set; } = new List<Boller>();

    public Plant() {}
    public Plant(DatabaseContext databaseContext): base(databaseContext) {}

    public void SumCalculate(int h, DateTime date)
    {
        if(h == 0) {
            h = Int32.Parse(date.ToString("HH"));
        }
        date = new DateTime(date.Year, date.Month, date.Day, 0,0,0);

        (new Hour(this.GetDbContext())).AddPlantReport(h, this.id, date);
        (new Day(this.GetDbContext())).AddPlantReport(this.id, date);
        (new Month(this.GetDbContext())).AddPlantReport(this.id, date);
    }

    public bool SumsCalculate(int hour)
    {
        bool status = true; DateTime date = DateTime.Now;

        try {
            foreach(Plant plant in this.GetDbContext().Plant.ToList()) {
                plant.SumCalculate(hour, date);
            }
        } catch(Exception e) { status = false; }

        return status;
    }

    public void SetRandomSettings()
    {
        PlantRepository pRepository = new PlantRepository(this.GetDbContext());
        PlantBollerRepository pbRepository = new PlantBollerRepository(this.GetDbContext());

        foreach(Plant plant in pRepository.All) {
            foreach (PlantBoller pb in plant.plantBollers) {
                pb.currentPower = (new Random()).Next(101);
                pbRepository.SaveOne(pb);
            }
        }
    }
}