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
    [Route(ApiConstants.AdminRoute + "userclaim")]
    public class UserClaimController : BaseUserClaimController
    {

        public UserClaimController(IUserClaimManager userClaimManager, ILocalizationService localizationService, ILogger<UserClaimController> logger, IMapper mapper)
        : base(userClaimManager, localizationService, logger, mapper)
        {

        }

    }
}
