namespace ViewModels.Users;

using Models;

public class IndexViewModels {
    public IEnumerable<User> users;

    public IndexViewModels(IEnumerable<User> users)
    {
        this.users = users;
    }
}