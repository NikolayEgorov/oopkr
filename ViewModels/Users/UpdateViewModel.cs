namespace ViewModels.Users;

using Models;

public class UpdateViewModels
{
    public User user;
    public string headerTitle;

    public UpdateViewModels(User user)
    {
        this.user = user;

        if(this.user.id == 0) {
            this.headerTitle = "Новий оператор";
        } else {
            this.headerTitle = "Профіль оператора: " + this.user.GetFullName();
        }
    }
}