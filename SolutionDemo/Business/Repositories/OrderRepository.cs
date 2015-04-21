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
        public void Edit(Order order)
        {
            ThrowOperationException(() =>
            {
                using (var db = new DemoDbContext())
                {
                    var updateOne = db.Orders.Find(order.Id);
                    updateOne.Operator = order.Operator;
                    updateOne.OtherFee = order.OtherFee;
                    db.SaveChanges();
                }
            });
            
        }
        public void Add(Order order)
        {
            ThrowOperationException(() =>
            {
                using (var db = new DemoDbContext())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            });
        }


        public void Delete(int id)
        {
            ThrowOperationException(() =>
            {
                using (var db = new DemoDbContext())
                {
                    var removeEntity = db.Orders.Find(id);
                    db.Orders.Remove(removeEntity);
                    db.SaveChanges();
                }
            });
        }
    }
}
