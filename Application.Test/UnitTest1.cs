using System;
using Xunit;

namespace Application.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //_options = Options.Create<Settings>(new Settings());
        }

        //[Fact]
        //public async Task Should_GetproductAsync()
        //{
        //    var mockDataHelper = new Mock<IDataHelper>();

        //    mockDataHelper.Setup(x => x.QuerySingleAsync<ProductEntity>(It.IsAny<string>(), It.IsAny<object>()))
        //        .Returns(Task.FromResult(new ProductEntity() { Id = 1, Name = "MockProduct1", Price = 159.99M }));

        //    var productRepo = new BasketRepository(mockDataHelper.Object);

        //    var sut = await productRepo.GetProduct(1);

        //    Assert.Equal(1, sut.Id);
        //    Assert.Equal("MockProduct1", sut.Name);
        //    Assert.Equal(159.99M, sut.Price);
        //}
    }
}