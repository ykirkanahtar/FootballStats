using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using FootballStats.WebApi.Constants;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.Name}")
                .MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiConstants.Name}, 25");

            RuleFor(x => x.Color).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.Color}")
                .MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiConstants.Color}, 25");
        }
    }
}