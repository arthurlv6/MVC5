using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Example.Web.Models;

namespace Example.Web.Controllers
{
    public class IndexController : Controller
    {
        public async Task<ActionResult> Index(int settingId=1)
        {
            var result = await Access.Instance.Gateway.GetCategories(settingId);
            return View(result);
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
    }
}