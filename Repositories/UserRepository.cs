namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUsers
{
    protected readonly DatabaseContext dbContext;
    
    public UserRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public User GetLast() => this.dbContext.User.OrderByDescending(u => u.id).First();
    public User GetById(int id) => this.dbContext.User.Where(u => u.id == id).First();
    public List<User> All => this.dbContext.User.ToList();

    public User SaveOne(User user)
    {
        User dbUser = null;

        if(user.id > 0) dbUser = this.GetById(user.id);
        else dbUser = new User();

        dbUser.name = user.name;
        dbUser.surname = user.surname;
        
        if(dbUser.id == 0) this.dbContext.Add(dbUser);
        this.dbContext.SaveChanges();

        return dbUser;
    }
    
    public bool RemoveById(int id)
    {
        this.dbContext.User.Remove(new User{ id = id });
        return this.dbContext.SaveChanges() > 0;
    }
}