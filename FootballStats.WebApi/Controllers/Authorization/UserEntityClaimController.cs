using AutoMapper;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Resources;
using FootballStats.WebApi.ApplicationSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootballStats.WebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]

    [Route(ApiConstants.AdminRoute + "userentityclaim")]
    public class UserEntityClaimController : BaseUserEntityClaimController
    {
        public UserEntityClaimController(IUserEntityClaimManager userEntityClaimManager, ILocalizationService localizationService, ILogger<UserEntityClaimController> logger, IMapper mapper)
        : base(userEntityClaimManager, localizationService, logger, mapper)
        {

        }
    }
}
