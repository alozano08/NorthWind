using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using NorthWind.Presenters;
using NorthWind.Repositories.EFCore.DataContext;
using NorthWind.Repositories.EFCore.Repositories;
using NorthWind.UseCases.Common.Validator;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;

namespace NorthWind.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddNorthWindServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<NorthWindContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("NorthWindDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

            return services;
        }
    }
}