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
    [Route(ApiConstants.AdminRoute + "user")]
    public class UserController : BaseUserController
    {
        public UserController(IUserManager userManager, ILocalizationService localizationService, ILogger<UserController> logger, IMapper mapper)
        : base(userManager, localizationService, logger, mapper)
        {

        }
    }
}
