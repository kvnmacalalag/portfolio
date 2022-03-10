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
    }
}
