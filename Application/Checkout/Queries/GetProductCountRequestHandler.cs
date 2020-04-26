using Application.Checkout.Command;
using Common.Model;
using MediatR.Pipeline;
using Persistance.Checkout;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Checkout.Queries
{
    public class GetProductCountRequestHandler : IRequestPreProcessor<AddProductToBasketRequest>
    {
        private readonly IStockRepository _stockRepository;

        public GetProductCountRequestHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task Process(AddProductToBasketRequest request, CancellationToken cancellationToken)
        {
            int stockCount = await _stockRepository.GetProductCount(request.ProductId);
            request.StockCount = stockCount;
        }
    }
}
