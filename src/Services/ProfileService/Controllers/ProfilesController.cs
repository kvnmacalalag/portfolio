using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ProfileService.Controllers.Base;
using ProfileService.Core.Profiles.Commands;
using ProfileService.Core.Profiles.Queries;

namespace Portfolio.ProfileService.Controllers
{

    public class ProfilesController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] GetProfilesRequest request)
            => Ok(await Mediator.Send(request));

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateProfileRequest request)
            => request.Profile == null ? BadRequest() : Result(await Mediator.Send(request));
    }
}