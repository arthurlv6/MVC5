using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class OperationRecord
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Type { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        [StringLength(20)]
        public string Ip { get; set; }
        [StringLength(100)]
        public string Controller { get; set; }
        [StringLength(100)]
        public string Action { get; set; }
    }
}
