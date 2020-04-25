using Common.Model;
using Infrastucture.Persistance;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Chekout;
using Persistance.Chekout;

namespace Persistance.Basket
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDataHelper _dataHelper;

        public BasketRepository(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public Task<int> AddProduct(BasketProduct basketProduct)
        {
            string sql = "INSERT INTO BasketProduct (BasketId, ProductId, [Count]) VALUES (@BasketId, @ProductId, @Count)";

            return _dataHelper.ExecuteAsync(sql, new { basketProduct.BasketId, basketProduct.ProductId });
        }
    }
}
