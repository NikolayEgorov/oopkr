namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class DayRepository: IDays
{
    protected readonly DatabaseContext dbContext;
    
    public DayRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<Day> All => this.dbContext.Day.ToList();
}