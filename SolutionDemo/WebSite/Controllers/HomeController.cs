using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Business.SubBusinessAccess;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeContainer _homeContainer;
        public HomeController(IHomeContainer homeContainer)
        {
            _homeContainer = homeContainer;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _homeContainer.Dispose();
            }
            base.Dispose(disposing);
        }

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

        public ActionResult Initialize()
        {
            _homeContainer.Initalize();
            return null;
        }
    }
}