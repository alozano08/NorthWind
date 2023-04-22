using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Repositories.EFCore.DataContext
{
    class NorthWindContextFactory : IDesignTimeDbContextFactory<NorthWindContext>
    {
        public NorthWindContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<NorthWindContext>();
            OptionBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;database=NorthWindDb");
            return new NorthWindContext(OptionBuilder.Options);
        }
    }
}