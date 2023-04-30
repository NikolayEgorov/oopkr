namespace ViewModels.Items;

using Models;

public class IndexViewModels
{
    public IEnumerable<Item> items;

    public IndexViewModels(IEnumerable<Item> items)
    {
        this.items = items;
    }
}