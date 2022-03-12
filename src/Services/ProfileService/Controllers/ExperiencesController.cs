using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ProfileService.Controllers.Base;
using Portfolio.ProfileService.Core.Experiences.Commands;
using Portfolio.ProfileService.Core.Experiences.Queries;

namespace Portfolio.ProfileService.Controllers
{
    public class ExperiencesController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] GetExperiencesRequest request)
            => Ok(await Mediator.Send(request));

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateExperienceRequest request)
            => request.Experience == null ? BadRequest() :
                Result(await Mediator.Send(request));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
            => id == 0 ? BadRequest() :
                Result(await Mediator.Send(new DeleteExperienceRequest { Id = id }));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateExperienceRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            if (request.Experience == null)
                return BadRequest();

            return Result(await Mediator.Send(request));
        }
    }
}