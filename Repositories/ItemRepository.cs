namespace Repositories;

using Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class ItemRepository : IItems
{
    protected readonly DatabaseContext dbContext;
    
    public ItemRepository(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Item GetLast() => this.dbContext.Item.OrderByDescending(i => i.id)
        .Include(i => i.products).First();
    public Item GetById(int id) => this.dbContext.Item
        .Include(i => i.products).Where(i => i.id == id).First();
    public List<Item> All => this.dbContext.Item
        .Include(i => i.products).ToList();

    public Item SaveOne(Item item)
    {
        if(item.id > 0) {
            Item dbItem = this.GetById(item.id);
            
            dbItem.title = item.title;
            dbItem.price = item.price;
            item = dbItem;
        } else this.dbContext.Item.Add(item);

        this.dbContext.SaveChanges();
        return item.id > 0 ? item : this.GetLast();
    }

    public bool RemoveById(int id)
    {
        this.dbContext.Item.Remove(new Item());
        return this.dbContext.SaveChanges() > 0;
    }

    public bool SaveProducts(Item item)
    {
        Item dbItem = this.GetById(item.id);
        dbItem.products.AddRange(item.products);
        
        return this.dbContext.SaveChanges() > 0;
    }
}