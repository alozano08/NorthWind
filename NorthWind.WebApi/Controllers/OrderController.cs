using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.UseCases.CreateOrder;

namespace NorthWind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) => 
            Mediator = mediator;

        [HttpPost("creater-order")]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderparams)
        {
            return await Mediator.Send(orderparams);
        }
    }
}