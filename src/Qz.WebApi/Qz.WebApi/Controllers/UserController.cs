using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Todos.GetTodoItems;
using Qz.Application.User.Login;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Qz.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        //[ProducesResponseType(typeof(LoginCommand), (int)HttpStatusCode.OK)]
        public async Task<QzResponse<LoginResponse>> Login([FromServices] IMediator mediator, LoginCommand request)
        {
            return Success<LoginResponse>(await mediator.Send(request));
        }
    }
}
