using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts.Base;
using Qz.Domain.Domains;
using System.Diagnostics;
using WebApi.YZGJ.Filters;

namespace Qz.WebApi.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        // TODO:
        public User CurrentUser { get; set; }

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
