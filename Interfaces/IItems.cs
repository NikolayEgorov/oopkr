namespace Interfaces;

using Models;

public interface IItems
{
    public Item GetLast();
    public Item GetById(int id);
    public List<Item> All { get; }
    public Item SaveOne(Item model);
    public bool RemoveById(int id);

    public bool SaveProducts(Item item);
}