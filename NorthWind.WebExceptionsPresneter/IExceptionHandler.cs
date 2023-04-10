using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthWind.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext Context);
    }
}