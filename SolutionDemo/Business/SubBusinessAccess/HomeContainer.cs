using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels;
using DataModel.DbContexts;
using DataModel.Entities;

namespace Business.SubBusinessAccess
{
    public interface IHomeContainer
    {
        bool Initalize();
        void RecordException(ErrorLog input, DemoDbContext dbContext);

        CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition,
            Expression<Func<T, TOrderBy>> orderBy, SortOrder sortOrder = SortOrder.Ascending)
            where T : class;

        void Dispose();
    }

    public class HomeContainer:CommonOperation, IHomeContainer
    {
        public bool Initalize()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    var order = new Order() { Customer = "Customer_" + i, CreateDate = DateTime.Now, CustomerPhone = "0210578463", Discount = 15, DeliveryFee = 20,OrderProducts = new Collection<OrderProduct>()};
                    for (int j = 1; j < 4; j++)
                    {
                        order.OrderProducts.Add(new OrderProduct() { Cost = 70, Price = 120, Quantity = j, Name = "Product" });
                    }
                    db.Orders.AddOrUpdate(order);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
