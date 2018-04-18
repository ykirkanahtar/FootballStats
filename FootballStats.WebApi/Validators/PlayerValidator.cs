using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using FootballStats.WebApi.Constants;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.Name}")
                .MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiConstants.Name}, 25");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.Surname}")
                .MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiConstants.Surname}, 25");
        }
    }
}