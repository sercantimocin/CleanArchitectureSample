using Common.Model;
using Domain.Products;
using Infrastucture.Persistance;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Persistance.Products
{
    public class ProductRepositoryTest
    {
        IOptions<Settings> _options;

        public ProductRepositoryTest()
        {
            _options = Options.Create<Settings>(new Settings());
        }

        [Fact]
        public async Task Should_GetproductAsync()
        {
            var mockDataHelper = new Mock<IDataHelper>();

            mockDataHelper.Setup(x => x.QuerySingleAsync<ProductEntity>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new ProductEntity() { Id = 1, Name = "MockProduct1", Price = 159.99M }));

            var productRepo = new ProductRepository(mockDataHelper.Object);

            var sut = await productRepo.GetProduct(1);

            Assert.Equal(1, sut.Id);
            Assert.Equal("MockProduct1", sut.Name);
            Assert.Equal(159.99M, sut.Price);
        }
    }
}
