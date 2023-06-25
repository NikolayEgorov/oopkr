namespace Interfaces;

using Models;

public interface IReport
{
    public Hour SaveOneHour(Hour hour);
    public List<Hour> AllHours { get; }
    public Day SaveOneDay(Day day);
    public List<Day> AllDays { get; }
    public Month SaveOneMonth(Month month);
    public List<Month> AllMonths { get; }
}