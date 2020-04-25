using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Checkout
{
    public class FakeStockRepository : IStockRepository
    {
        public Task<int> GetProductCount(int productId)
        {
            return Task.FromResult(3);
        }

        public Task<int> UpdateProductCount(int productId, int count)
        {
            return Task.FromResult(1);
        }
    }
}
