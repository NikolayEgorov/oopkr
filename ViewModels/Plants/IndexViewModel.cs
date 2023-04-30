namespace ViewModels.Plants;

using Models;

public class IndexViewModels
{
    public IEnumerable<Plant> plants;

    public IndexViewModels(IEnumerable<Plant> plants)
    {
        this.plants = plants;
    }
}