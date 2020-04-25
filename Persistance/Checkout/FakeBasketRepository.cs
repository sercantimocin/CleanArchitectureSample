using Domain.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Checkout
{
    public class FakeBasketRepository : IBasketRepository
    {
        public Task<int> AddProduct(BasketProduct basketProduct)
        {
            return Task.FromResult(1);
        }
    }
}
