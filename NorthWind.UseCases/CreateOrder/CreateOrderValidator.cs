using FluentValidation;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty()
                .WithMessage("Debe proporcionar el identificador del cliente.");
            RuleFor(c => c.RequestData.ShipAdress).NotEmpty()
                .WithMessage("Debe proporcionar la dirección de envío.");
            RuleFor(c => c.RequestData.ShipCity).NotEmpty().MaximumLength(3)
                .WithMessage("Debe proporcionarl al menos tres carácteres del nombre de la ciudad.");
            RuleFor(c => c.RequestData.ShipCountry).NotEmpty().MaximumLength(3)
                .WithMessage("Debe proporcionarl al menos tres carácteres del nombre del país.");
            RuleFor(c => c.RequestData.OderDetails).Must(d => d != null && d.Any())
                .WithMessage("Deben especificarse los productos de la orden");
        }
    }
}