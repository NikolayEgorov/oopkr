namespace Models;

using Repositories;

public class Report: Base
{
    public Report(){}
    public Report(DatabaseContext db): base(db) {}

    protected ReportRepository GetRepository()
    {
        return new ReportRepository(this.GetDbContext());
    }
}