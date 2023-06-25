namespace Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Hour: Report
{
    public int hour { get; set; } = 0;
    public int plantId { get; set; }
    public double power { get; set; } = 0;
    public double gas { get; set; } = 0;
    [Column(TypeName="datetime")]
    public DateTime date { get; set; } = DateTime.Now;

    public Hour(){}
    public Hour(DatabaseContext db): base(db) {}

    public void AddPlantReport(int h, int plantId, DateTime date)
    {
        if(this.GetRepository().GetByHourPlantIdAndDate(h, plantId, date) == null) {
            List<PlantBoller> pbs = this.GetDbContext().PlantBoller.Where(pb => pb.plantId == plantId).ToList();

            double[] sums = {0.0, 0.0};
            foreach(PlantBoller pb in pbs) {
                Boller boller = this.GetDbContext().Boller.Where(b => b.id == pb.bollerId).First();
                double curPower = ((double) pb.currentPower) / 100;

                sums[0] += boller.generatePower * curPower; 
                sums[1] += boller.consumptionPower * curPower;
            }

            this.GetRepository().SaveOneHour(new Hour(){ hour = h, plantId = plantId,
                power = sums[0], gas = sums[1], date = date });
        }
    }
}