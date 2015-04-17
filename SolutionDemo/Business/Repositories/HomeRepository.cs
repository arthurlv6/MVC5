using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels;
using DataModel.DbContexts;
using DataModel.Entities;

namespace Business.Repositories
{
    public interface IHomeRepository
    {
        bool Initalize();
        void RecordException(ErrorLog input, DemoDbContext dbContext);

        CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition,
            Expression<Func<T, TOrderBy>> orderBy, SortOrder sortOrder = SortOrder.Ascending)
            where T : class;

        void Dispose();
    }

    public class HomeRepository:CommonOperation, IHomeRepository
    {
        public bool Initalize()
        {
            using (var db=new DemoDbContext())
            {
                try
                {
                    for (int i = 0; i < 50; i++)
                    {
                        var order = new Order() { Customer = "Customer_" + i, CreateDate = DateTime.Now, CustomerPhone = "0210578463", Discount = 15, DeliveryFee = 20, OrderProducts = new Collection<OrderProduct>() };
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

        public override CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition, Expression<Func<T, TOrderBy>> orderBy,
            SortOrder sortOrder = SortOrder.Ascending)
        {
            using (var db = new DemoDbContext())
            {
                var result = new CommonSearchVm<T>();
                List<T> group;
                int total = db.Set<T>().Count(condition.Func);
                var totalPages = total / condition.PerPageSize + (total % condition.PerPageSize > 0 ? 1 : 0);
                if (condition.CurrentPage > totalPages)
                {
                    condition.CurrentPage = 1;
                }
                if (sortOrder == SortOrder.Ascending)
                {
                    group =
                        db.Set<T>()
                            .Where(condition.Func)
                            .OrderBy(orderBy)
                            .Skip((condition.CurrentPage - 1) * condition.PerPageSize)
                            .Take(condition.PerPageSize)
                            .Include("OrderProducts")
                            .ToList();
                }
                else
                {
                    group =
                        db.Set<T>()
                            .Where(condition.Func)
                            .OrderByDescending(orderBy)
                            .Skip((condition.CurrentPage - 1) * condition.PerPageSize)
                            .Take(condition.PerPageSize)
                            .Include("OrderProducts")
                            .ToList();
                }
                result.Data = group;

                result.TotalPages = totalPages == 0 ? 1 : totalPages;
                result.PerPageSize = condition.PerPageSize;
                result.CurrentPage = condition.CurrentPage;
                return result;
            }
        }
    }
}
