using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qz.Application.Base;
using Qz.Application.Projects.CreateProject;
using Qz.Application.Projects.ListProject;

namespace Qz.WebApi.Controllers
{
    [Route("api/Organization/{organizationId}/[controller]")]
    public class ProjectsController : BaseController
    {
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IMediator mediator, ILogger<ProjectsController> logger)
            : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("listProjects")]
        public async Task<ListProjectResponse> ListProjects(long organizationId, ListProjectRequest request)
        {
            request.OrganizationId = organizationId;
            return await RequestAsync<ListProjectRequest, ListProjectResponse>(request);
        }

        [HttpPost("createProject")]
        public async Task<CreateProjectResponse> CreateProject(long organizationId, CreateProjectRequest request)
        {
            request.OrganizationId = organizationId;
            request.CreatedBy = CurrentUser.UserId;

            return await RequestAsync<CreateProjectRequest, CreateProjectResponse>(request);
        }

        // DELETE /organization/{organizationId}/projects/delete
        // POST /organization/{organizationId}/projects/{projectId}/updateMember
        // GET /organization/{organizationId}/project/{projectId}
        // GET /organization/{organizationId}/projects/listTemplates
    }
}
