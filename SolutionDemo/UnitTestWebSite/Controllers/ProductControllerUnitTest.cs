using System;
using System.Web.Mvc;
using Business.Repositories;
using DataModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using WebSite.Controllers;

namespace UnitTestWebSite.Controllers
{
    [TestClass]
    public class ProductControllerUnitTest
    {
        [TestMethod]
        public void Edit_GetReturnModel()
        {
            var id = 1;
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(()=>repo.GetById(id)).Returns(new Product(){Id=id});

            var controller = new ProductsController(repo);
            var viewResult = (ViewResult) controller.Edit(id);
            var model = (Product) viewResult.Model;
            Assert.AreEqual(id,model.Id);
        }
        [TestMethod]
        public void Edit_GetReturnNotFound()
        {
            var id = 1;
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetById(id)).Returns((Product)null);

            var controller = new ProductsController(repo);
            var result = controller.Edit(id);
            Assert.IsTrue(result is HttpNotFoundResult);
        }
        [TestMethod]
        public void Edit_PostReturnNotFound()
        {
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetById(1)).Returns((Product)null);

            var controller = new ProductsController(repo);
            var result = controller.Edit(new Product(){Id=1});
            Assert.IsTrue(result is HttpNotFoundResult);
        }
        [TestMethod]
        public void Edit_PostModelStateModel()
        {
            var id = 1;
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetById(id)).Returns(new Product() { Id = id });

            var controller = new ProductsController(repo);
            var viewResult = (ViewResult)controller.Edit(id);
            controller.ViewData.ModelState.AddModelError("","message");
            var model = (Product)viewResult.Model;
            Assert.AreEqual(id, model.Id);
        }
        [TestMethod]
        public void Edit_PostReturnRedirection()
        {
            var repo = Mock.Create<IProductRepository>();
            var controller = new ProductsController(repo);
            Mock.Arrange(() => repo.Edit(Arg.IsAny<Product>())).MustBeCalled();
            var result = controller.Edit(new Product());
            
            Mock.Assert(repo);
            Assert.IsTrue(result is RedirectToRouteResult);
        }
    }
}
