using System.Threading.Tasks;
using Domain.Chekout;

namespace Persistance.Chekout
{
    public interface IBasketRepository
    {
        Task<int> AddProduct(BasketProduct basketProduct);
    }
}
