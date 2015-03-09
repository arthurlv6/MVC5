using System.Collections.ObjectModel;
using DataModel.Entities;

namespace DataModel.DbContexts.DemoMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.DbContexts.DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DbContexts\DemoMigrations";
        }

        protected override void Seed(DataModel.DbContexts.DemoDbContext context)
        {
            for (int i = 0; i < 50; i++)
            {
                var order = new Order() { Customer = "Customer_" + i, CreateDate = DateTime.Now, CustomerPhone = "0210578463", Discount = 15, DeliveryFee = 20, OrderProducts = new Collection<OrderProduct>() };
                for (int j = 1; j < 4; j++)
                {
                    if (i % 2 == 0)
                        order.OrderProducts.Add(new OrderProduct() { Cost = 70, Price = 120, Quantity = j, Name = "Product" + j, Profile = string.Format("car{0}.jpg", j) });
                    order.OrderProducts.Add(new OrderProduct() { Cost = 70, Price = 120, Quantity = j, Name = "Product" + j, Profile = string.Format("clothes{0}.jpg", j) });
                }
                context.Orders.AddOrUpdate(order);
            }
            context.SaveChanges();
        }
    }
}
