using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Issue;
using Qz.Application.Orgs.ListOrg;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    [Route("collab/[controller]/[action]")]
    public class IssueController : BaseController
    {
        IMediator mediator;

        public IssueController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<QzResponse<MyIssueResponse>> MyIssueAsync([Required]long orgId)
        {
            var res = await mediator.Send(new MyIssueCommand()
            {
                OrgId = orgId,
                UserId = CurrentUser.UserId
            });

            return Success(res);
        }
    }
}
