using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Issue;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    [Route("api/Organization/{organizationId}/[controller]")]
    public class WorkitemsController : BaseController
    {
        public WorkitemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("MyIssue")]
        public async Task<MyIssueResponse> MyIssueAsync([Required] long organizationId)
        {
            return await RequestAsync<MyIssueCommand, MyIssueResponse>(new MyIssueCommand()
            {
                OrgId = organizationId,
                UserId = CurrentUser.UserId
            });
        }

        // POST /organization/{organizationId}/workitems/create

        // POST /organization/{organizationId}/workitems/update

        // GET /organization/{organizationId}/workitems/{workitemId}

        // GET /organization/{organizationId}/workitems/{workitemId}/getActivity

        // DELETE /organization/{organizationId}/workitem/delete
    }
}
