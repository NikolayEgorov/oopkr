// namespace Repositories;

// using Models;
// using Interfaces;
// using Microsoft.EntityFrameworkCore;

// public class OrderRepository : IOrders
// {
//     protected readonly DatabaseContext dbContext;
    
//     public OrderRepository(DatabaseContext dbContext)
//     {
//         this.dbContext = dbContext;
//     }

//     public Order GetLast() => (Order) this.dbContext.Order
//         .OrderByDescending(o => o.id).Include(o => o.user).Include(o => o.items).First();

//     public Order GetById(int id) => (Order) this.dbContext.Order
//         .Where(o => o.id == id).Include(o => o.user).Include(o => o.items).First();

//     public List<Order> All => this.dbContext.Order
//         .Include(o => o.user).Include(o => o.items).ToList();
    
//     public Order SaveOne(Order order)
//     {
//         Order dbOrder = null;

//         if(order.id > 0) dbOrder = this.GetById(order.id);
//         else dbOrder = new Order();
        
//         if(order.user.id > 0) {
//             dbOrder.user = this.dbContext.User
//                 .Where(u => u.id == order.user.id).First();
//         }

//         if(dbOrder.id == 0) this.dbContext.Add(dbOrder);
        
//         this.dbContext.SaveChanges();
//         return dbOrder;
//     }

//     public bool SaveItems(Order order)
//     {
//         int totalPrice = order.items.Sum(i => i.price);

//         Order dbOrder = this.GetById(order.id);
//         dbOrder.items.AddRange(order.items);

//         dbOrder.totalPrice = totalPrice;
//         return this.dbContext.SaveChanges() > 0;
//     }

//     public bool RemoveById(int id) {
//         this.dbContext.Order.Remove(new Order());
//         return this.dbContext.SaveChanges() > 0;
//     }
// }