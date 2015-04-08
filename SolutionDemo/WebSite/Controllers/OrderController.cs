using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Business.Repositories;

namespace WebSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _orderRepository.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            try
            {
                var data = _orderRepository.GetOrders();
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