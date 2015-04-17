using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        void RecordException(ErrorLog input, DemoDbContext dbContext);

        CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition,
            Expression<Func<T, TOrderBy>> orderBy, SortOrder sortOrder = SortOrder.Ascending)
            where T : class;

        void Dispose();
    }

    public class OrderRepository:CommonOperation, IOrderRepository
    {
        public IEnumerable<Order> GetOrders()
        {
            using (var db = new DemoDbContext())
            {
                return db.Orders.Take(3).Include(d=>d.OrderProducts).ToList();
            }
        }  
    }
}
