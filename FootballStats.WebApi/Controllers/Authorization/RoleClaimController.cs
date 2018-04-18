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
    [Route(ApiConstants.AdminRoute + "roleclaim")]
    public class RoleClaimController : BaseRoleClaimController
    {
        public RoleClaimController(IRoleClaimManager roleClaimManager, ILocalizationService localizationService, ILogger<RoleClaimController> logger, IMapper mapper)
        : base(roleClaimManager, localizationService, logger, mapper)
        {

        }
    }
}
