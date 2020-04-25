using Infrastucture.Persistance;
using System.Threading.Tasks;

namespace Persistance.Checkout
{
    public class StockRepository : IStockRepository
    {
        private readonly IDataHelper _dataHelper;

        public StockRepository(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public Task<int> GetProductCount(int productId)
        {
            string sql = "SELECT [Count] FROM Stock WHERE ProductId = @ProductId";

            return _dataHelper.QuerySingleAsync<int>(sql, new { productId });
        }

        public Task<int> UpdateProductCount(int productId, int count)
        {
            string sql = "UPDATE Stock SET [Count] = @Count WHERE ProductId = @ProductId";

            return _dataHelper.ExecuteAsync(sql, new { productId, count });
        }
    }
}
