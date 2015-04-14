using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Example.Web.Models;
using Example.Web.Models.Courses;
using Example.Web.Models.Registration;

namespace Example.Web.Controllers
{
    public class HomeController : ApiController
    {
        public async Task<List<CategoryM>> Get()
        {
            //var categories = new List<CategoryM>();
            return await Access.Instance.Gateway.GetCategories(1);
            //return categories;
        }
    }
}
