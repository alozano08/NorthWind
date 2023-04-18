using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.Exceptions;
using NorthWind.IoC;
using NorthWind.Repositories.EFCore.DataContext;
using NorthWind.WebExceptionsPresenter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
options.Filters.Add(new ApiExceptionFilterAttribute(
    new Dictionary<Type, IExceptionHandler>
    {
        {typeof(GeneralException), new GeneralExceptionHandler()},
        {typeof(ValidationException), new ValidationExceptionHandler()},
    }
    )));
builder.Services.AddNorthWindServices(builder.Configuration);

builder.Services.AddDbContext<NorthWindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
