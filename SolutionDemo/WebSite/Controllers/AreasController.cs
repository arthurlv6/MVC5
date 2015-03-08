using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.SubBusinessAccess;
using WebSite.Filters;

namespace WebSite.Controllers
{
    public class AreasController : Controller
    {
        private ISponsor _sponsor;
        //[LoginFilter]
        public AreasController(ISponsor sponsor)
        {
            _sponsor = sponsor;
        }
        public ActionResult Index()
        {
            try
            {
                var data = _sponsor.GetAreas();
                return View(data);
            }
            catch (Exception)
            {
                throw new Exception(message: "An exception occured");
            }
        }

        // GET: Areas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                View("BespokeError").ExecuteResult(ControllerContext);
                filterContext.ExceptionHandled = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sponsor.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
