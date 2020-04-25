using Application.Checkout.Command;
using Common.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("help")]
        public string Get()
        {
            return "Hello";
        }

        [HttpPost("item")]
        public async Task<ResponseModel<bool>> AddBasketProductAsync(AddProductToBasketRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}