using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.SubBusinessAccess;

namespace WebSite.Controllers
{
    public class OrderController : Controller
    {
        private IOrderContainer _orderContainer;
        public OrderController(IOrderContainer orderContainer)
        {
            _orderContainer = orderContainer;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _orderContainer.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            try
            {
                var data = _orderContainer.GetOrders();
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
    }
}