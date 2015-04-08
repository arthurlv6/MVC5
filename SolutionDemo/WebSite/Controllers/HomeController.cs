using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Business.Repositories;
using DataModel.Entities;
using Business.ViewModels;
namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _homeContainer;
        public HomeController(IHomeRepository homeContainer)
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

        public ActionResult OrderIndex()
        {
            Expression<Func<Order, bool>> searchName = t => true ;
            var model = new CommonSearchVm<Order>() { CurrentPage = 1, PerPageSize = 10, Func = searchName };
            var result = _homeContainer.GetSearchResult(model, d => d.Id, SortOrder.Descending);
            return View(result);
        }
        [HttpPost]
        public ActionResult OrderIndex(CommonSearchVm<Order> input)
        {
            if (input.CurrentPage == 0) //search
            {
                input.PerPageSize = 10;
                input.CurrentPage = 1;
            }
            Expression<Func<Order, bool>> searchName;
            if (string.IsNullOrEmpty(input.Search))
            {
                searchName = t => true;
            }
            else
            {
                searchName = t => t.Customer.Contains(input.Search);
            }
            Expression<Func<Order, bool>> category;
            if (input.SearchTwo == null)
            {
                category = c => true;
            }
            else
            {
                category = c => true;
            }
            var lambda = Expression.Lambda<Func<Order, bool>>(Expression.AndAlso(
            new SwapVisitor(searchName.Parameters[0], category.Parameters[0]).Visit(searchName.Body),
            category.Body), category.Parameters);

            input.Func = lambda;
            var model = _homeContainer.GetSearchResult(input, d => d.Id, SortOrder.Descending);
            return View(model);
        }
    }
}