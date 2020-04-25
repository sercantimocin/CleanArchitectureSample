using Application.Checkout.Command;
using Common.Model;
using Domain.Checkout;
using MediatR;
using Persistance.Checkout;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Products.Command
{
    public class AddProductToBasketRequestHandler : IRequestHandler<AddProductToBasketRequest, ResponseModel<bool>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IStockRepository _stockRepository;

        public AddProductToBasketRequestHandler(IBasketRepository basketRepository, IStockRepository stockRepository)
        {
            _basketRepository = basketRepository;
            _stockRepository = stockRepository;
        }

        public async Task<ResponseModel<bool>> Handle(AddProductToBasketRequest request, CancellationToken cancellationToken)
        {
            int stockCount = await _stockRepository.GetProductCount(request.ProductId);

            if (request.Count > stockCount)
            {
                return new ResponseModel<bool>(HttpStatusCode.OK, "Insufficient product count", false);
            }

            using (TransactionScope scope = new TransactionScope())
            {
                int effectedCount = await _stockRepository.UpdateProductCount(request.ProductId, request.Count);
                if (effectedCount <= 0)
                {
                    return new ResponseModel<bool>(HttpStatusCode.OK, "The operation cannot successful", false);
                }

                effectedCount = await _basketRepository.AddProduct(new BasketProduct
                {
                    BasketId = request.BasketId,
                    ProductId = request.ProductId,
                    Count = request.Count
                });

                if (effectedCount <= 0)
                {
                    return new ResponseModel<bool>(HttpStatusCode.OK, "The operation cannot successful", false);
                }

                scope.Complete();
            }

            return new ResponseModel<bool>(true);
        }
    }
}
