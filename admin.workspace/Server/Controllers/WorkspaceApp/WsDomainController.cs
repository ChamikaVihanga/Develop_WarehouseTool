using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.WorkspaceApp;

namespace admin.workspace.Server.Controllers.WorkspaceApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class WsDomainController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<WsDomain>>> GetWsDomains()
        {
            throw new NotImplementedException();
        }
    }
}
