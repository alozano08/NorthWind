using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.UseCases.CreateOrder;

namespace NorthWind.WebApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) => 
            Mediator = mediator;

        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderparams)
        {
            return await Mediator.Send(orderparams);
        }
    }
}