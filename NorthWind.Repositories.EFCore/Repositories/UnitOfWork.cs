using NorthWind.Entities.Interfaces;
using NorthWind.Repositories.EFCore.DataContext;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly NorthWindContext Context;
        public UnitOfWork(NorthWindContext context) =>
            Context = context;
        public Task<int> SaveChangeAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}