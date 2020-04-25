using Domain.Checkout;
using System.Threading.Tasks;

namespace Persistance.Checkout
{
    public interface IBasketRepository
    {
        Task<int> AddProduct(BasketProduct basketProduct);
    }
}
