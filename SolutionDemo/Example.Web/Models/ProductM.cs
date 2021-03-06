﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Web.Models
{
    public class ProductM
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Price{ get; set; }
        public string Profile{ get; set; }
        public string PerPay{ get; set; }
        public string RRP { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? CategoryParentId { get; set; }
        public string CategoryName { get; set; }
        public string Paypal { get; set; }
    }
}
