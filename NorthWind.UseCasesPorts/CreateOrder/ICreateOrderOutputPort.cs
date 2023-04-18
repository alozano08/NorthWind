namespace NorthWind.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderOutputPort
    {
        Task Handle(int orderId);
    }
}