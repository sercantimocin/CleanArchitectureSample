using Common.Model;
using MediatR;
using Newtonsoft.Json;

namespace Application.Checkout.Command
{

    public class AddProductToBasketRequest : IRequest<ResponseModel<bool>>
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        [JsonIgnore] 
        public int StockCount { get; set; }
    }
}
