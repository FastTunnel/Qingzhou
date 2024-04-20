using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts.Base;
using Qz.WebApi.Filters;
using System.Text.Json;

namespace Qz.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    [Route("collab/[controller]")]
    public class BaseController : ControllerBase
    {
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
        public virtual QzResponse Success(object data, string? msg = null)
        {
            return new QzResponse
            {
                Success = true,
                Data = data,
                Message = msg,
                TraceId = Request.HttpContext.TraceIdentifier
            };
        }

        [NonAction]
        public virtual QzResponse Fail(object data, string msg)
        {
            return new QzResponse
            {
                Success = false,
                Data = data,
                Message = msg,
                TraceId = Request.HttpContext.TraceIdentifier
            };
        }
    }
}
