namespace ViewModels.Home;

using Models;

public class IndexViewModels
{
    public IEnumerable<Plant> plants;
    public IEnumerable<Boller> bollers;

    public IndexViewModels(IEnumerable<Plant> plants, IEnumerable<Boller> bollers)
    {
        this.plants = plants;
        this.bollers = bollers;
    }
}