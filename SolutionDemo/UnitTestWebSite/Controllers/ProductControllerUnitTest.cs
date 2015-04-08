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
        public void Edit_ReturnModel()
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
        public void Edit_ReturnNotFound()
        {
            var id = 1;
            var repo = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repo.GetById(id)).Returns((Product)null);

            var controller = new ProductsController(repo);
            var result = controller.Edit(id);
            Assert.IsTrue(result is HttpNotFoundResult);
        }
    }
}
