using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Business.Repositories;
using DataModel.Entities;
namespace WebSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductsController():this(new ProductRepository())
        {
            
        }
        // GET: Products
        public async Task<ActionResult> Index()
        {
            var data = await _productRepository.GetAllAsync();
            return View(data);
        }

    

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                await _productRepository.AddAsync(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _productRepository.GetByIdAsync(id);
            if (model == null)
            {
                //ModelState.AddModelError(string.Empty, "the id does not exist.");
                return HttpNotFound();
            }
            else
            {
                return View(model);    
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var model = await _productRepository.GetByIdAsync(product.Id);
            if (model == null)
                return HttpNotFound();
            try
            {
                // TODO: Add update logic here
                await _productRepository.EditAsync(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<JsonResult> _DeleteConfirm(int id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
                return Json("done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("fail", JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
