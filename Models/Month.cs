namespace Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Month: Report
{
    public int plantId { get; set; }
    public double power { get; set; } = 0;
    public double gas { get; set; } = 0;
    [Column(TypeName="datetime")]
    public DateTime date { get; set; } = DateTime.Now;

    public Month(){}
    public Month(DatabaseContext db): base(db) {}

    public void AddPlantReport(int plantId, DateTime date)
    {
        double powerSum = this.GetDbContext().Day.Where(d => d.plantId == plantId)
            .Where(d => d.date >= date && d.date <= date).Select(d => d.power).Sum();

        double gasSum = this.GetDbContext().Day.Where(d => d.plantId == plantId)
            .Where(d => d.date >= date && d.date <= date).Select(d => d.gas).Sum();

        Month month = this.GetRepository().GetMonthByPlantIdAndDate(plantId, date);
        if(month == null) month = new Month(){ plantId = plantId, date = date };

        month.gas = gasSum;
        month.power = powerSum;

        this.GetRepository().SaveOneMonth(month);
    }
}