﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Features.Auth.Login;
using NtierArchitecture.Business.Features.Auth.Register;
using NtierArchitectureWebApi.Abstractions;

namespace NtierArchitectureWebApi.Controllers
{
    [AllowAnonymous]
    public sealed class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
