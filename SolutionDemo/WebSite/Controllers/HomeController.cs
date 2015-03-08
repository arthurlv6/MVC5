using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
        public ActionResult Index()
        {
            //throw new Exception(message: "An exception occured");
            //HttpContext.GetGlobalResourceObject("", "");
            return View();
        }
        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page." ;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}