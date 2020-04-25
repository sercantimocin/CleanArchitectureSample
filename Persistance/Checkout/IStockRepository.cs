using System.Threading.Tasks;

namespace Persistance.Checkout
{
    public interface IStockRepository
    {
        Task<int> GetProductCount(int productId);
        Task<int> UpdateProductCount(int productId, int count);
    }
}
