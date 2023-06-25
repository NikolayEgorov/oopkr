namespace ViewModels.Home;

using Models;

public class IndexViewModels
{
    public double hourGenerate = 0;
    public double hourConsumption = 0;
    public List<Hour> hours = new List<Hour>();

    public double dayGenerate = 0;
    public double dayConsumption = 0;
    public List<Day> days = new List<Day>();

    public double monthGenerate = 0;
    public double monthConsumption = 0;
    public List<Month> months = new List<Month>();

    public double allGenerate = 0;
    public double allConsumption = 0;

    public List<Plant> plants = new List<Plant>();

    private void HoursInit(List<Hour> hours)
    {
        Hour hour = null; int lastHour = 0;
        foreach(Hour hr in hours) {
            if(lastHour != hr.hour) {
                if(hour != null) this.hours.Add(hour);
                hour = null;
            }

            if(hour == null) {
                hour = new Hour();
                hour.hour = hr.hour;

                lastHour = hour.hour;
            }
            
            hour.power += hr.power;
            hour.gas += hr.gas;
        }
        if(hour != null) this.hours.Add(hour);
    }

    private void DaysInit(List<Day> days)
    {
        Day day = null; int lastDay = 0;
        foreach(Day d in days) {
            if(lastDay != d.date.Day) {
                if(day != null) this.days.Add(day);
                day = null;
            }

            if(day == null) {
                day = new Day();
                day.date = d.date;

                lastDay = day.date.Day;
            }
            
            day.power += d.power;
            day.gas += d.gas;
        }
        if(day != null) this.days.Add(day);
    }

    private void InitPlants(DatabaseContext db)
    {
        this.plants = db.Plant.Where(plants => plants.id > 0).ToList();
    }

    public IndexViewModels(DatabaseContext db)
    {
        Report report = new Report(db);

        DateTime date = DateTime.Now;
        date = new DateTime(date.Year, date.Month, date.Day, 0,0,0);

        List<Hour> hours = report.GetDbContext().Hour
            .Where(h => h.date >= date).OrderBy(h => h.hour).ToList();
        
        this.HoursInit(hours);
        foreach(Hour hour in hours) {
            if(hour.hour == DateTime.Now.Hour) {
                this.hourGenerate += hour.power;
                this.hourConsumption += hour.gas;
            }

            this.dayGenerate += hour.power;
            this.dayConsumption += hour.gas;
        }

        List<Day> days = report.GetDbContext().Day
            .Where(d => d.date.Month >= date.Month).OrderBy(d => d.date).ToList();
        
        this.DaysInit(days);
        foreach(Day day in days) {
            this.monthGenerate += day.power;
            this.monthConsumption += day.gas;
        }

        List<Month> months = report.GetDbContext().Month
            .Where(m => m.date.Year >= date.Year).ToList();
        foreach(Month month in months) {
            this.allGenerate += month.power;
            this.allConsumption += month.gas;
        }

        this.InitPlants(db);
    }
}