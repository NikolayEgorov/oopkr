namespace ViewModels.Bollers;

using Models;

public class UpdateViewModels
{
    public Boller boller;
    public string headerTitle;

    public UpdateViewModels(Boller boller)
    {
        this.boller = boller;

        if(this.boller.id == 0) {
            this.headerTitle = "Новий оператор";
        } else {
            this.headerTitle = "Профіль оператора: " + this.boller.title;
        }
    }
}