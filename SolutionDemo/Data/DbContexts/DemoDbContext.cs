using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataModel.DbContexts
{
    public class DemoDbContext : IdentityDbContext<ApplicationUser>
    {
        public DemoDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
       
        public DbSet<OperationRecord> OperationRecords { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public static DemoDbContext Create()
        {
            return new DemoDbContext();
        }
    }
}
