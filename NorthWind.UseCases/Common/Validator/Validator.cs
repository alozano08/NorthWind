using FluentValidation;
using FluentValidation.Results;

namespace NorthWind.UseCases.Common.Validator
{
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model,
            IEnumerable<IValidator<Model>> validators, bool causeException = true)
        {
            var Failures = validators
                .Select(v => v.Validate(model))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (Failures.Any() && causeException)
            {
                throw new ValidationException(Failures);
            }

            return Task.FromResult(Failures);
        }
    }
}