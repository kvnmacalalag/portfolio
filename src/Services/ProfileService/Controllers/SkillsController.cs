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
    }
}