using Common.Model;
using Domain.Products;
using Infrastucture.Persistance;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Products
{
    [TestClass]
    public class ProductRepositoryTest
    {
        IOptions<Settings> _options;

        public ProductRepositoryTest()
        {
            _options = Options.Create<Settings>(new Settings());
        }

        [TestMethod]
        public async Task Should_GetproductAsync()
        {
            var mockDataHelper = new Mock<IDataHelper>();
            //mockDataHelper.Setup(x => x.QuerySingleAsync<ProductEntity>(It.IsAny<string>(), It.IsAny<object>()))
            //    .Returns(Task.FromResult(new ProductEntity() { Id = 1, Name = "MockProduct1", Price = 159.99M }));

            var productRepo = new ProductRepository(mockDataHelper.Object);

            var sut = await productRepo.GetProduct(1);

            Assert.AreEqual(1, sut.Id);
            Assert.AreEqual("MockProduct1", sut.Name);
            Assert.AreEqual(159.99M, sut.Price);
        }
    }
}
