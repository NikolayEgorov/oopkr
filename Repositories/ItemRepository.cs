// namespace Repositories;

// using Models;
// using Interfaces;
// using Microsoft.EntityFrameworkCore;

// public class ItemRepository : IItems
// {
//     protected readonly DatabaseContext dbContext;
    
//     public ItemRepository(DatabaseContext dbContext)
//     {
//         this.dbContext = dbContext;
//     }

//     public Base GetLast() => this.dbContext.Item.OrderByDescending(i => i.id)
//         .Include(i => i.products).First();
//     public Base GetById(int id) => this.dbContext.Item
//         .Include(i => i.products).Where(i => i.id == id).First();
    
//     public Base SaveOne(Base model)
//     {
//         Item item = (Item) model;
//         if(item.id > 0) {
//             Item dbItem = (Item) this.GetById(item.id);
            
//             dbItem.title = item.title;
//             dbItem.price = item.price;
//             item = dbItem;
//         } else this.dbContext.Item.Add(item);

//         this.dbContext.SaveChanges();
//         return item.id > 0 ? item : this.GetLast();
//     }

//     public bool RemoveById(int id)
//     {
//         this.dbContext.Item.Remove(new Item(id));
//         return this.dbContext.SaveChanges() > 0;
//     }

//     public List<Item> All => this.dbContext.Item
//         .Include(i => i.products).ToList();

//     public bool SaveProducts(Item item)
//     {
//         Item dbItem = (Item) this.GetById(item.id);
//         dbItem.products.AddRange(item.products);
        
//         return this.dbContext.SaveChanges() > 0;
//     }
// }