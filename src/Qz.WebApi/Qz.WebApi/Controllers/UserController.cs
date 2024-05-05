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
        public UserController(IMediator mediator)
            : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<LoginResponse> GetToken(LoginCommand request)
        {
            return await RequestAsync<LoginCommand, LoginResponse>(request);
        }
    }
}
