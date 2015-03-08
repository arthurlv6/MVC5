using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        //[ActionName("ErrorPage")]
        public ActionResult Index(string message="")
        {
            ViewBag.message = message;
            return View();
        }
    }
}