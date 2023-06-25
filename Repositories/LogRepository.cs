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

        this.dbContext.Add(log);
        this.dbContext.SaveChanges();

        return log;
    }

    public bool RemoveById(int id)
    {
        return false;
    }

    public void Lg(string message, Log.Type type = Log.Type.log)
    {
        Log log = new Log();

        log.setType(type);
        log.message = message;
        
        this.SaveOne(log);
    }
}