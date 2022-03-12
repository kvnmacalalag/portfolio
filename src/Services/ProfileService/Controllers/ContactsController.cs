using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ProfileService.Controllers.Base;
using Portfolio.ProfileService.Core.Contacts.Commands;
using Portfolio.ProfileService.Core.Contacts.Queries;

namespace Portfolio.ProfileService.Controllers
{
    public class ContactsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetContactsRequest request)
            => Ok(await Mediator.Send(request));


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateContactRequest request)
            => request.Contact == null ? BadRequest() : Result(await Mediator.Send(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
            => id == 0 ? BadRequest() :
                Result(await Mediator.Send(new DeleteContactRequest { Id = id }));

        [HttpPut("{id}")]
        public async Task<IActionResult> PatchAsync(int id, [FromBody] UpdateContactRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            if (request.Contact == null)
                return BadRequest();

            return Result(await Mediator.Send(
                new UpdateContactRequest { Id = id, Contact = request.Contact }));
        }

    }
}
