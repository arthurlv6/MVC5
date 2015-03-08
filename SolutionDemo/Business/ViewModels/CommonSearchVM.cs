using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class CommonSearchVm<T> where T : class
    {
        public CommonSearchVm()
        {
            Data = new List<T>();
        }
        public int CurrentPage { get; set; }
        public int PerPageSize { get; set; }
        public int TotalPages { get; set; }
        public int Status { get; set; }
        public string Search { get; set; }
        public string SearchTwo { get; set; }
        public List<T> Data { get; set; }
        public Expression<Func<T, bool>> Func { get; set; }
    }
}
