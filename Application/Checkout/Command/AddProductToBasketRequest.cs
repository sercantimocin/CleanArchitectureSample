using Common.Model;
using MediatR;

namespace Application.Checkout.Command
{
    public class AddProductToBasketRequest : IRequest<ResponseModel<bool>>
    {
        public int BasketId { get; set; }

        public int ProducId { get; set; }

        public int Count { get; set; }
    }
}
