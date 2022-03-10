using Portfolio.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.ProfileService.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult Result<T>(BaseResponse<T> response)
        {
            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }
            else
            {
                var details = new ValidationProblemDetails(response.Errors)
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                };

                return BadRequest();
            }
        }
    }
}