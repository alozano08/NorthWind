using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly NorthWindContext Context;
        public OrderRepository(NorthWindContext context) =>
            Context = context;        

        public void Create(Order order)
        {
            Context.Add(order);
        }

        public IEnumerable<Order> GetOrderByEspecification(Specification<Order> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Orders.Where(ExpressionDelegate);
        }
    }
}