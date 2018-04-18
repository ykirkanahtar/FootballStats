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
    [Route(ApiConstants.AdminRoute + "clientapplication")]
    public class ClientApplicationController : BaseClientApplicationController
    {
        public ClientApplicationController(IClientApplicationManager clientApplicationManager, ILocalizationService localizationService, ILogger<ClientApplicationController> logger, IMapper mapper)
            : base(clientApplicationManager, localizationService, logger, mapper)
        {

        }
    }
}
