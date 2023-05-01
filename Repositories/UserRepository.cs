namespace Repositories;

using Dto;
using Models;
using Interfaces;

public class UserRepository : IUsers
{
    protected readonly DatabaseContext dbContext;
    
    public UserRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Base GetLast() => this.dbContext.User.OrderByDescending(u => u.id).First();
    public Base GetById(int id) => this.dbContext.User.Where(u => u.id == id).First();

    public User? AuthenticateUser(UserDto model)
    {
        if(this.dbContext.User.Count() == 0) return null;

        User user = this.dbContext.User
            .Where(u => u.email.Equals(model.email)).First();

        return BCrypt.Net.BCrypt.Verify(model.password, user.password)
            ? user : null;
    }

    public User PasswordHashing(User user)
    {
        user.password = BCrypt.Net.BCrypt
            .HashPassword(user.password);

        return user;
    }

    public Base SaveOne(Base model)
    {
        User dbUser = null; User user = (User) model;

        if(user.id > 0) dbUser = (User) this.GetById(user.id);
        else dbUser = new User();

        dbUser.name = user.name;
        dbUser.email = user.email;
        dbUser.surname = user.surname;
        dbUser.password = user.password;
        
        if(dbUser.id == 0) this.dbContext.Add(dbUser);
        this.dbContext.SaveChanges();

        return dbUser;
    }
    
    public bool RemoveById(int id)
    {
        this.dbContext.User.Remove(new User{ id = id });
        return this.dbContext.SaveChanges() > 0;
    }

    public List<User> All => this.dbContext.User.ToList();
}