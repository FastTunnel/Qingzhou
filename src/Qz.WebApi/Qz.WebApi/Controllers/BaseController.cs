using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts.Base;

namespace Qz.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public virtual QzResponse Success(object data, string? msg = null)
        {
            return new QzResponse
            {
                Success = true,
                Data = data,
                message = msg
            };
        }

        [NonAction]
        public virtual QzResponse Fail(object data, string msg)
        {
            return new QzResponse
            {
                Success = false,
                Data = data,
                message = msg
            };
        }
    }
}
