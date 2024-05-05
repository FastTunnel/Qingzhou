using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Base.Commands;
using Qz.Application.Base.Queries;
using Qz.Application.Projects.ListProject;
using Qz.WebApi.Filters;
using System.Text.Json;

namespace Qz.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [NonAction]
        protected async Task<TResult> RequestAsync<TCommand, TResult>(TCommand command)
            where TCommand : IRequest<TResult>
        {
            return await mediator.Send(command);
        }

        public CurrentUser CurrentUser
        {
            get
            {
                var user = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "User");
                if (user != null)
                {
                    return JsonSerializer.Deserialize<CurrentUser>(user.Value)!;
                }

                throw new Exception("解析用户认证信息失败");
            }
        }

        [NonAction]
        public virtual ErrorInfo Fail<T>(string msg, Dictionary<string, string[]> erros)
        {
            return new ErrorInfo(msg, erros, Request.HttpContext.TraceIdentifier);
        }
    }
}
