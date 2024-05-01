using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qz.WebApi.Controllers
{
    [Route("api/Organization/{organizationId}/[controller]")]
    public class ProjectsController : BaseController
    {
        [HttpGet("listProjects")]
        public void listProjects(long organizationId)
        {

        }

        [HttpPost("createProject")]
        public void createProject()
        {

        }

        // DELETE /organization/{organizationId}/projects/delete
        // POST /organization/{organizationId}/projects/{projectId}/updateMember
        // GET /organization/{organizationId}/project/{projectId}
        // GET /organization/{organizationId}/projects/listTemplates
    }
}
