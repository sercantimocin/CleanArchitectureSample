using Application.Checkout.Command;
using Common.Const;
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
            // StockCount get value via GetProductCountRequestHandler which run before the current request
            if (request.Count > request.StockCount)
            {
                return new ResponseModel<bool>(HttpStatusCode.OK, Errors.InsufficientStockCount, false);
            }

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                int effectedCount = await _stockRepository.UpdateProductCount(request.ProductId, request.Count);
                if (effectedCount <= 0)
                {
                    scope.Dispose();
                    return new ResponseModel<bool>(HttpStatusCode.OK, Errors.OperationFailed, false);
                }

                //TODO AutoMapper useful for object mapping
                effectedCount = await _basketRepository.AddProduct(new BasketProduct
                {
                    BasketId = request.BasketId,
                    ProductId = request.ProductId,
                    Count = request.Count
                });

                if (effectedCount <= 0)
                {
                    scope.Dispose();
                    return new ResponseModel<bool>(HttpStatusCode.OK, Errors.OperationFailed, false);
                }

                scope.Complete();
            }

            return new ResponseModel<bool>(true);
        }
    }
}
