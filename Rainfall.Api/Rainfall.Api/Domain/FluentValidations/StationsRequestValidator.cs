using FluentValidation;
using Rainfall.Api.Domain.Request;

namespace Rainfall.Api.Domain.FluentValidations
{
    public class StationsRequestValidator : AbstractValidator<StationsRequest>
    {
        public StationsRequestValidator()
        {
            RuleFor(x => x.StationId).NotEmpty().WithMessage("Invalid Request");

            RuleFor(x => x.Count).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
        }
    }
}
