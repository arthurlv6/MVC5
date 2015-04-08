using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.DbContexts;
using DataModel.Entities;

namespace Business.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);

        void Edit(Product product);

        Product GetById(int id);
    }

    public class ProductRepository : CommonOperation, IProductRepository
    {
        public Product GetById(int id)
        {
            return new Product();
        }
        public void Edit(Product product)
        {
            using (var db = new DemoDbContext())
            {
                var updateOne=db.Products.Find(product.Id);
                updateOne.Name = product.Name;
                updateOne.Profile = product.Profile;
                db.SaveChanges();
            }
        }
        public void Add(Product product)
        {
            using (var db=new DemoDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}
