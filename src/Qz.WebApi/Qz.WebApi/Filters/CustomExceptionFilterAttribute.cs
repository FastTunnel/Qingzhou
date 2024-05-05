using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Qz.Application.Base;

namespace Qz.WebApi.Filters
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
            var res = new ErrorInfo("异常：" + context.Exception.Message, null, context.HttpContext.TraceIdentifier);

            var result = new JsonResult(res) { StatusCode = StatusCodes.Status200OK };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
