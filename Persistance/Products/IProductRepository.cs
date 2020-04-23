using System.Threading.Tasks;
using Domain.Products;

namespace Persistance.Products
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetProduct(int id);
    }
}
