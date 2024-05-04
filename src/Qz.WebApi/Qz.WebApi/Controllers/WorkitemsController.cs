﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Issue;
using System.ComponentModel.DataAnnotations;

namespace Qz.WebApi.Controllers
{
    [Route("api/Organization/{organizationId}/[controller]")]
    public class WorkitemsController : BaseController
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IMediator mediator;

        public WorkitemsController(ILogger<OrganizationController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet("MyIssue")]
        public async Task<QzResponse<MyIssueResponse>> MyIssueAsync([Required] long orgId)
        {
            var res = await mediator.Send(new MyIssueCommand()
            {
                OrgId = orgId,
                UserId = CurrentUser.UserId
            });

            return Success(res);
        }

        // POST /organization/{organizationId}/workitems/create

        // POST /organization/{organizationId}/workitems/update

        // GET /organization/{organizationId}/workitems/{workitemId}

        // GET /organization/{organizationId}/workitems/{workitemId}/getActivity

        // DELETE /organization/{organizationId}/workitem/delete
    }
}
