using CustomFramework.WebApiUtils.Constants;
using FluentValidation;
using FootballStats.WebApi.Constants;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Validators
{
    public class MatchValidator : AbstractValidator<Match>
    {
        public MatchValidator()
        {
            RuleFor(x => x.Order).Equal(0)
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.Order}");

            RuleFor(x => x.DurationInMinutes).Equal(0)
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.DurationInMinutes}");

            RuleFor(x => x.HomeTeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.HomeTeamId}");

            RuleFor(x => x.AwayTeamId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiConstants.AwayTeamId}");

            RuleFor(x => x.VideoLink).MaximumLength(100)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiConstants.VideoLink}, 100");

        }

    }
}