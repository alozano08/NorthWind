using FluentValidation;
using NorthWind.Entities.Exceptions;
using NorthWind.IoC;
using NorthWind.WebExceptionsPresenter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
options.Filters.Add(new ApiExceptionFilterAttribute(
    new Dictionary<Type, IExceptionHandler>
    {
        {typeof(GeneralException), new GeneralExceptionHandler()},
        {typeof(ValidationException), new ValidationExceptionHandler()}
    }
    )));
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
