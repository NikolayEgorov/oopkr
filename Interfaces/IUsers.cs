namespace Interfaces;

using Models;

public interface IUsers
{
    public User GetLast();
    public User GetById(int id);
    public User SaveOne(User user);
    public List<User> All { get; }
    public bool RemoveById(int id);
    // public IEnumerable<Order> orders { get; }
}