using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class Child
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Area Area { get; set; }
        public string Profile { get; set; }
        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } 
    }
}
