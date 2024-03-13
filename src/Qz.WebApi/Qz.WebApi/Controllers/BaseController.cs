using Microsoft.AspNetCore.Mvc;
using Qz.Application.Contracts;

namespace Qz.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public virtual QzResponse Success(object data)
        {
            return new QzResponse
            {
                Success = true,
                Data = data
            };
        }

        [NonAction]
        public virtual QzResponse Fail(object data)
        {
            return new QzResponse
            {
                Success = false,
                Data = data
            };
        }
    }
}
