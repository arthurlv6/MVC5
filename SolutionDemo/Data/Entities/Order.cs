using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class Order
    {

        public int Id { get; set; }
        [DefaultValue("Warehouse Northshore")]
        public string Warehouse { get; set; }
        [DefaultValue("John")]
        public string Customer { get; set; }
        public string CustomerPhone { get; set; }
        [DefaultValue("Arthur")]
        public string Operator { get; set; }
        [DefaultValue("David")]
        public string Salesman { get; set; }
        public DateTime CreateDate { get; set; }
        public double Discount { get; set; }
        [DefaultValue(0)]
        public double DeliveryFee { get; set; }
        [DefaultValue(0)]
        public double OtherFee { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } 
    }
}
