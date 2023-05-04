namespace Interfaces;

using Dto;
using Models;

public interface IUsers : IBase
{   
    public User PasswordHashing(User user);
    public User GetByLogin(string login);
    public User? AuthenticateUser(UserDto model);
    public List<User> All { get; }
}