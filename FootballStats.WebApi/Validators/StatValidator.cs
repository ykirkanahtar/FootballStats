using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using FootballStats.WebApi.Constants;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Validators
{
    public class StatValidator : AbstractValidator<Stat>
    {
        public StatValidator()
        {
            RuleFor(x => x.MatchId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.MatchId}");

            RuleFor(x => x.TeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.TeamId}");

            RuleFor(x => x.PlayerId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.PlayerId}");
        }
    }
}