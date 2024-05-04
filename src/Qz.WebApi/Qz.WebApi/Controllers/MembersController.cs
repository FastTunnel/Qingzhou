using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Members.GetMember;
using Qz.Application.Members.ListMembers;

namespace Qz.WebApi.Controllers
{
    [Route("api/Organization/{organizationId}/[controller]")]
    public class MembersController : BaseController
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IMediator mediator;

        public MembersController(ILogger<OrganizationController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<QzResponse<ListMembersResponse>> ListMembers(long organizationId)
        {
            return Success(await mediator.Send(new ListMembersRequest
            {
                OrganizationId = organizationId
            }));
        }

        [HttpGet("{accountId}")]
        public async Task<QzResponse<MemberResponse>> Member(long organizationId, long accountId)
        {
            return Success(await mediator.Send(new MemberRequest
            {
                AccountId = accountId,
                OrganizationId = organizationId
            }));
        }
    }
}
