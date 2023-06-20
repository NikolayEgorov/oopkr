namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class HourRepository: IHours
{
    protected readonly DatabaseContext dbContext;
    
    public HourRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<Hour> All => this.dbContext.Hour.ToList();
}