using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;
        public OrderController(ICreateOrderInputPort inputPort, 
            ICreateOrderOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(
            CreateOrderParams orderParams)
        {           
            await InputPort.Handle(orderParams);
            var Presenter = OutputPort as CreateOrderPresenter;
            return Presenter.Content;
        }
    }
}