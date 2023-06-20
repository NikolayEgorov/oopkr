namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class MonthRepository: IMonths
{
    protected readonly DatabaseContext dbContext;
    
    public MonthRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<Month> All => this.dbContext.Month.ToList();
}