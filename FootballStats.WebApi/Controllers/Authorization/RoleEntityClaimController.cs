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
    [Route(ApiConstants.AdminRoute + "roleentityclaim")]
    public class RoleEntityClaimController : BaseRoleEntityClaimController
    {
        public RoleEntityClaimController(IRoleEntityClaimManager roleEntityClaimManager, ILocalizationService localizationService, ILogger<RoleEntityClaimController> logger, IMapper mapper)
        : base(roleEntityClaimManager, localizationService, logger, mapper)
        {

        }
    }
}
