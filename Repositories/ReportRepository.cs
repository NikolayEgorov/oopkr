namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class ReportRepository: IReport
{
    protected readonly DatabaseContext dbContext;
    
    public ReportRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<Hour> AllHours => this.dbContext.Hour.ToList();
    public Hour SaveOneHour(Hour hour)
    {
        if(hour.id == 0){
            this.dbContext.Hour.Add(hour);
        }
        this.dbContext.SaveChanges();

        return this.dbContext.Hour.OrderByDescending(h => h.id).First();
    }

    public Hour GetByHourPlantIdAndDate(int hour, int plantId, DateTime date)
    {
        return this.dbContext.Hour.Where(h => h.hour == hour).Where(h => h.plantId == plantId)
            .Where(h => h.date >= date && h.date <= date).FirstOrDefault() ?? null;
    }

    public List<Hour> GetHourByPlantIdAndDate(int plantId, DateTime date)
    {
        return this.dbContext.Hour.Where(hour => hour.plantId == plantId)
            .Where(hour => hour.date >= date && hour.date <= date).ToList();
    }

    public List<Day> AllDays => this.dbContext.Day.ToList();
    public Day SaveOneDay(Day day)
    {
        if(day.id == 0) {
            this.dbContext.Day.Add(day);
        }
        this.dbContext.SaveChanges();

        return this.dbContext.Day.OrderByDescending(d => d.id).First();
    }

    public Day GetDayByPlantIdAndDate(int plantId, DateTime date)
    {
        return this.dbContext.Day.Where(d => d.plantId == plantId)
            .Where(d => d.date >= date && d.date <= date).FirstOrDefault() ?? null;
    }

    public List<Month> AllMonths => this.dbContext.Month.ToList();
    public Month SaveOneMonth(Month month)
    {
        if(month.id == 0) {
            this.dbContext.Month.Add(month);
        }
        this.dbContext.SaveChanges();

        return this.dbContext.Month.OrderByDescending(m => m.id).First();
    }

    public Month GetMonthByPlantIdAndDate(int plantId, DateTime date)
    {
        return this.dbContext.Month.Where(m => m.plantId == plantId)
            .Where(m => m.date >= date && m.date <= date).FirstOrDefault() ?? null;
    }
}