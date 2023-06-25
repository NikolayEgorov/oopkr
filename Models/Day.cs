namespace Models;

using Repositories;
using System.ComponentModel.DataAnnotations.Schema;

public class Day: Report
{
    public int plantId { get; set; }
    public double power { get; set; } = 0;
    public double gas { get; set; } = 0;

    [Column(TypeName="datetime")]
    public DateTime date { get; set; } = DateTime.Now;

    public Day(){}
    public Day(DatabaseContext db): base(db) {}

    public void AddPlantReport(int plantId, DateTime date)
    {
        double powerSum = this.GetDbContext().Hour.Where(h => h.plantId == plantId)
            .Where(h => h.date >= date && h.date <= date).Select(h => h.power).Sum();

        double gasSum = this.GetDbContext().Hour.Where(h => h.plantId == plantId)
            .Where(h => h.date >= date && h.date <= date).Select(h => h.gas).Sum();

        Day day = this.GetRepository().GetDayByPlantIdAndDate(plantId, date);
        if(day == null) day = new Day(){ plantId = plantId, date = date };

        day.gas = gasSum;
        day.power = powerSum;

        this.GetRepository().SaveOneDay(day);
    }
}