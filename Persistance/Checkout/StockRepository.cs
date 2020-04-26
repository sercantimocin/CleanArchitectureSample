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
            string sql = "SELECT [Count] FROM Stock (NOLOCK) WHERE ProductId = @ProductId";

            return _dataHelper.QuerySingleAsync<int>(sql, new { productId });
        }

        public Task<int> UpdateProductCount(int productId, int count)
        {
            string sql = @"DECLARE @CountTemp int=0
                          SELECT @CountTemp = [Count] from Stock WHERE ProductId = @ProductId
                          IF ( @CountTemp >= @Count )
                          BEGIN
                            @CountTemp=@CountTemp-@Count;
                            UPDATE Stock SET [Count] = @CountTemp WHERE ProductId = @ProductId
                          END";

            return _dataHelper.ExecuteAsync(sql, new { productId, count });
        }
    }
}
