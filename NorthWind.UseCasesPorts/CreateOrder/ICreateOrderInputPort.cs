using NorthWind.UseCasesDTOs.CreateOrder;

namespace NorthWind.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort
    {
        Task Handle(CreateOrderParams Order);
    }
}