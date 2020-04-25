using Domain.Chekout;
using Infrastucture.Model;
using MediatR;
using Persistance.Basket;
using Persistance.Checkout;
using Persistance.Chekout;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
            /*
             * 1-)validate model
             */

            int stockCount = await _stockRepository.GetProductCount(request.ProducId);

            if (request.Count > stockCount)
            {
                return new ResponseModel<bool>(HttpStatusCode.OK, "Insufficient product count", false);
            }

            using (TransactionScope scope = new TransactionScope())
            {
                int effectedCount = await _stockRepository.UpdateProductCount(request.ProducId, request.Count);
                if (effectedCount <= 0)
                {
                    return new ResponseModel<bool>(HttpStatusCode.OK, "The operation cannot successful", false);
                }

                effectedCount = await _basketRepository.AddProduct(new BasketProduct
                {
                    BasketId = request.BasketId,
                    ProductId = request.ProducId,
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
