using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderByEspecification(Specification<Order> specification);
    }
}