using MediatR;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Features.UserRoles.SetUserRole;
using NtierArchitectureWebApi.Abstractions;

namespace NtierArchitectureWebApi.Controllers
{
    public sealed class USerRolesController : ApiController
    {
        public USerRolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }
    }
}
