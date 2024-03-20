using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts.Base;
using Qz.Application.Contracts.Dtos;

namespace Qz.WebApi.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<QzResponse> PostAsync([FromServices] IMediator mediator, LoginRequest request)
        {
            return Success(await mediator.Send(request));
        }
    }
}
