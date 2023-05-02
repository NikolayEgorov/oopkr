namespace ViewModels.Users;

using Models;

public class UpdateViewModels
{
    public string action;
    public User user;

    public UpdateViewModels(string action, User user)
    {
        this.action = action;
        this.user = user;
    }
}