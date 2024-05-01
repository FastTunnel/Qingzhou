using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
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
        public virtual QzResponse<T> Success<T>(T data, string? msg = null)
        {
            return new QzResponse<T>
            {
                Success = true,
                Data = data,
                Message = msg,
                TraceId = Request.HttpContext.TraceIdentifier
            };
        }

        [NonAction]
        public virtual QzResponse<T> Fail<T>(T data, string msg)
        {
            return new QzResponse<T>
            {
                Success = false,
                Data = data,
                Message = msg,
                TraceId = Request.HttpContext.TraceIdentifier
            };
        }
    }
}
