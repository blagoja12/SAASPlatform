using AS.eJP.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAASLogic.Queries;
using SAASPersistence.DataContracts;

namespace SAASPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatfromPackagesController : ControllerBase
    {      

        private readonly ILogger<PlatfromPackagesController> _logger;
        private readonly IMediator _mediator;

        public PlatfromPackagesController(ILogger<PlatfromPackagesController> logger,  IMediator _mediator)
        {
            _logger = logger;
            this._mediator = _mediator;
        }

        [HttpGet]
        public ActionResult<RequestResult<RecommendedSubscription>> RecommendPackage([FromQuery] GetUserSubscriptionPackageQuery query)
        {
            return _mediator.Send(query).Result;
        }
    }
}
