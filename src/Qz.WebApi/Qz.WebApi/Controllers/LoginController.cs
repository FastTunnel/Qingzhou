using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.User.Login;
using System.Net;

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
        [ProducesResponseType(typeof(QzResponse), (int)HttpStatusCode.OK)]
        public async Task<QzResponse> PostAsync([FromServices] IMediator mediator, LoginCommand request)
        {
            return Success(await mediator.Send(request));
        }
    }
}
