using Application.Checkout.Command;
using Application.Products.Command;
using Common.Const;
using Domain.Checkout;
using Moq;
using Persistance.Checkout;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test
{
    public class AddProductToBasketRequestHandlerTest
    {
        [Fact]
        public async Task Should_Response_true_When_StockCount_greater_than_basket_Count()
        {
            var mockBasketRepo = new Mock<IBasketRepository>();
            mockBasketRepo.Setup(x => x.AddProduct(It.IsAny<BasketProduct>())).Returns(Task.FromResult(1));

            var mockStockRepo = new Mock<IStockRepository>();
            mockStockRepo.Setup(x => x.UpdateProductCount(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(1));

            var handler = new AddProductToBasketRequestHandler(mockBasketRepo.Object, mockStockRepo.Object);

            var request = new AddProductToBasketRequest() { BasketId = 1, ProductId = 100, Count = 1, StockCount = 3 };

            var sut = await handler.Handle(request, new CancellationToken());

            Assert.Equal(HttpStatusCode.OK, sut.StatusCode);
            Assert.Equal(string.Empty, sut.Message);
            Assert.True(sut.Data);
        }

        [Fact]
        public async Task Should_Response_false_When_StockCount_less_than_basket_Count()
        {
            var mockBasketRepo = new Mock<IBasketRepository>();
            mockBasketRepo.Setup(x => x.AddProduct(It.IsAny<BasketProduct>())).Returns(Task.FromResult(1));

            var mockStockRepo = new Mock<IStockRepository>();
            mockStockRepo.Setup(x => x.UpdateProductCount(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(1));

            var handler = new AddProductToBasketRequestHandler(mockBasketRepo.Object, mockStockRepo.Object);

            var request = new AddProductToBasketRequest() { BasketId = 1, ProductId = 100, Count = 4, StockCount = 3 };

            var sut = await handler.Handle(request, new CancellationToken());

            Assert.Equal(HttpStatusCode.OK, sut.StatusCode);
            Assert.Equal(Errors.InsufficientStockCount, sut.Message);
            Assert.False(sut.Data);
        }

    }
}
