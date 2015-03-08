using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Child> Children { get; set; }
    }
}
