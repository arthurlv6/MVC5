using System;
using System.Collections.Generic;
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
    public interface IOrderContainer
    {
        IEnumerable<Order> GetOrders();
        void RecordException(ErrorLog input, DemoDbContext dbContext);

        CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition,
            Expression<Func<T, TOrderBy>> orderBy, SortOrder sortOrder = SortOrder.Ascending)
            where T : class;

        void Dispose();
    }

    public class OrderContainer:CommonOperation, IOrderContainer
    {
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders.Include("OrderProducts").Take(3);
        }  
    }
}
