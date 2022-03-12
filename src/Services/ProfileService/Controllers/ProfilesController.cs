using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ProfileService.Controllers.Base;
using Portfolio.ProfileService.Core.Profiles.Commands;
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
            => request.MyProfile == null ? BadRequest() : Result(await Mediator.Send(request));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
            => id == 0 ? BadRequest() :
                Result(await Mediator.Send(new DeleteProfileRequest { Id = id }));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateProfileRequest request)
        {
            if (id == 0 || request.Id == 0)
                return BadRequest();
            if (id != request.Id)
                return BadRequest();
            if (request.MyProfile == null)
                return BadRequest();

            return Result(await Mediator.Send(
                new UpdateProfileRequest { Id = id, MyProfile = request.MyProfile }));
        }
    }
}