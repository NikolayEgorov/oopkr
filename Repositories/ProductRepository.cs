// namespace Repositories;

// using Models;
// using Interfaces;

// public class ProductRepository : IProducts
// {
//     protected readonly DatabaseContext dbContext;
    
//     public ProductRepository(DatabaseContext dbContext)
//     {
//         this.dbContext = dbContext;
//     }

//     public Product GetLast() => this.dbContext.Product.OrderByDescending(p => p.id).First();
//     public Product GetById(int id) => this.dbContext.Product.Where(p => p.id == id).First();
//     public List<Product> All => this.dbContext.Product.ToList();
    
//     public Product SaveOne(Product product)
//     {   
//         Product dbProduct = null;

//         if(product.id > 0) dbProduct = this.GetById(product.id);
//         else dbProduct = new Product();

//         dbProduct.title = product.title;
        
//         if(dbProduct.id == 0) this.dbContext.Add(dbProduct);
//         this.dbContext.SaveChanges();

//         return dbProduct;
//     }

//     public bool RemoveById(int id)
//     {
//         Product product = this.GetById(id);
//         this.dbContext.Product.Remove(product);
//         this.dbContext.SaveChanges();

//         return this.dbContext.SaveChanges() > 0;
//     }
// }