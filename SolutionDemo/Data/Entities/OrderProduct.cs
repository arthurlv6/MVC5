using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(1)]
        public double Quantity { get; set; }
        [DefaultValue(100)]
        public double Price { get; set; }
        [DefaultValue(80)]
        public double Cost { get; set; }
        public string Profile { get; set; }
        public Order Order { get; set; }
    }
}
