using Infrastucture.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Command
{
    public class AddProductToBasketRequest : IRequest<ResponseModel<bool>>
    {
        public int BasketId { get; set; }

        public int ProducId { get; set; }

        public int Count { get; set; }
    }
}
