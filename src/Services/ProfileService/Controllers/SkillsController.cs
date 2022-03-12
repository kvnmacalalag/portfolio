using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ProfileService.Controllers.Base;
using Portfolio.ProfileService.Core.Skills.Commands;
using Portfolio.ProfileService.Core.Skills.Queries;

namespace ProfileService.Controllers
{
    public class SkillsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] GetSkillsRequest request)
            => Ok(await Mediator.Send(request));

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateSkillRequest request)
            => request.Skill == null ? BadRequest() : Result(await Mediator.Send(request));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
            => id == 0 ? BadRequest() :
                Result(await Mediator.Send(new DeleteSkillRequest { Id = id }));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateSkillRequest request)
        {
            if (id == 0 || request.Id == 0)
                return BadRequest();
            if (id != request.Id)
                return BadRequest();
            if (request.Skill == null)
                return BadRequest();

            return Result(await Mediator.Send(new UpdateSkillRequest { Id = id, Skill = request.Skill }));
        }


    }
}