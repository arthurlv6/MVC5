using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Business.Repositories;
using DataModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.JustMock.Expectations.Abstraction;
using WebSite.Controllers;

namespace UnitTestWebSite.Controllers
{
    [TestClass]
    public class ProductControllerUnitTest
    {
        [TestMethod, TestCategory("Async"),]
        public async Task Edit_GetReturnModel()
        {
            var id = 1;
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetByIdAsync(id))
                .Returns(Task.FromResult(new Product(){Id = 1}));

            var controller = new ProductsController();
            var controllerActionResult= await controller.Edit(id);
            var viewResult = (ViewResult) controllerActionResult;
            var model = (Product)viewResult.Model;
            Assert.AreEqual(id, model.Id);
        }
        [TestMethod]
        public async Task Edit_PostReturnRedirection()
        {
            var repo = Mock.Create<IProductRepository>();
            var controller = new ProductsController(repo);
            Mock.Arrange(() => repo.GetByIdAsync(Arg.IsAny<int>()))
                .Returns(Task.FromResult<Product>(new Product()));

            Mock.Arrange(() => repo.EditAsync(Arg.IsAny<Product>()))
               .Returns(Task.FromResult((object)null))
               .MustBeCalled();

            var result = await controller.Edit(new Product());

            Mock.Assert(repo);
            Assert.IsTrue(result is RedirectToRouteResult);
        }
        [TestMethod]
        public async Task Edit_GetReturnNotFound()
        {
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetByIdAsync(Arg.IsAny<int>()))
                .Returns(Task.FromResult((Product)null));

            var controller = new ProductsController(repo);
            var result =await controller.Edit(Arg.IsAny<int>());
            Assert.IsTrue(result is HttpNotFoundResult);
        }

        [TestMethod]
        public async Task Edit_PostReturnNotFound()
        {
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetByIdAsync(Arg.IsAny<int>()))
                .Returns(Task.FromResult((Product)null));

            var controller = new ProductsController(repo);
            var result = await controller.Edit(new Product(){Id = 1});
            Assert.IsTrue(result is HttpNotFoundResult);
        }

        [TestMethod]
        public async Task Edit_PostModelStateModel()
        {
            var id = 1;
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetByIdAsync(id))
                .Returns(Task.FromResult(new Product() { Id = id }));

            var controller = new ProductsController(repo);
            var controllerEdit =await controller.Edit(id);
            var viewResult = (ViewResult) controllerEdit;
            controller.ViewData.ModelState.AddModelError("", "message");
            var model = (Product)viewResult.Model;
            Assert.AreEqual(id, model.Id);
        }
       
    }

}
