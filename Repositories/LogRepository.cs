namespace Repositories;

using Models;
using Interfaces;

public class LogRepository: ILog
{
    protected readonly DatabaseContext dbContext;
    
    public LogRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Base GetLast()
    {
        return new Log();
    }

    public Base GetById(int id)
    {
        return new Log();
    }

    public Base SaveOne(Base model)
    {
        Log log = (Log) model;
        return log;
    }

    public bool RemoveById(int id)
    {
        return false;
    }

    public void Lg(string message)
    {
        Log log = new Log();
        
        log.message = message;
        log.date = DateTime.Now;
        
        this.dbContext.Add(log);
        this.dbContext.SaveChanges();
    }
}