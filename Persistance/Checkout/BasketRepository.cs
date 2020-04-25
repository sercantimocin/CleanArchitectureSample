using Domain.Checkout;
using Infrastucture.Persistance;
using System.Threading.Tasks;

namespace Persistance.Checkout
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
