using FluentValidation;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty()
                .WithMessage("Debe proporcionar el identificador del cliente.");
            RuleFor(c => c.ShipAdress).NotEmpty()
                .WithMessage("Debe proporcionar la dirección de envío.");
            RuleFor(c => c.ShipCity).NotEmpty().MaximumLength(3)
                .WithMessage("Debe proporcionarl al menos tres carácteres del nombre de la ciudad.");
            RuleFor(c => c.ShipCountry).NotEmpty().MaximumLength(3)
                .WithMessage("Debe proporcionarl al menos tres carácteres del nombre del país.");
            RuleFor(c => c.OderDetails).Must(d => d != null && d.Any())
                .WithMessage("Deben especificarse los productos de la orden");
        }
    }
}