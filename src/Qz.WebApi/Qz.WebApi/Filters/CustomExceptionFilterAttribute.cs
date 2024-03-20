using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Qz.Application.Contracts.Base;

namespace WebApi.YZGJ.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "【全局异常捕获】");
            var res = new QzResponse()
            {
                Success = false,
                Data = null,
                Message = context.Exception.Message,
                TraceId = context.HttpContext.TraceIdentifier
            };
 
            var result = new JsonResult(res) { StatusCode = 200 };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
