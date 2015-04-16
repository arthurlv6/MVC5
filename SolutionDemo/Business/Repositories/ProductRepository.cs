using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.DbContexts;
using DataModel.Entities;

namespace Business.Repositories
{
    public interface IProductRepository
    {
         Task AddAsync(Product product);

         Task EditAsync(Product product);

         Task DeleteAsync(int id);
         Task<Product> GetByIdAsync(int id);
         Task<List<Product>> GetAllAsync();
    }

    public class ProductRepository : CommonOperation, IProductRepository
    {
        public async Task<Product> GetByIdAsync(int id)
        {
                using (var db = new DemoDbContext())
                {
                    return await db.Products.FindAsync(id);
                }
        }
        public async Task<List<Product>> GetAllAsync()
        {
            using (var db = new DemoDbContext())
            {
                var data = await db.Products.Include(d=>d.Category).ToListAsync();
                return data;
            }
        }
        public async Task EditAsync(Product product)
        {
            using (var db = new DemoDbContext())
            {
                var updateOne=db.Products.Find(product.Id);
                updateOne.Name = product.Name;
                updateOne.Cost = product.Cost;
                updateOne.Price = product.Price;
                updateOne.Profile = product.Profile;
                await db.SaveChangesAsync();
            }
        }
        public async Task AddAsync(Product product)
        {
            using (var db=new DemoDbContext())
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            using (var db = new DemoDbContext())
            {
                var removeEntity= await db.Products.FindAsync(id);
                db.Products.Remove(removeEntity);
                await db.SaveChangesAsync();
            }
        }
    }
}
