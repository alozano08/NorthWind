using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly NorthWindContext Context;
        public OrderDetailRepository(NorthWindContext context) => 
            Context = context;
        

        public void Create(OrderDetail orderDetail)
        {
            Context.Add(orderDetail);
        }
    }
}