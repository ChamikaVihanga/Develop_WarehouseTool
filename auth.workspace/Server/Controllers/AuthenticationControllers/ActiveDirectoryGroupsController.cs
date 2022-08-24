
using auth.workspace.Server.ActiveDirectoryAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.AccountManagement;

namespace auth.workspace.Server.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveDirectoryGroupsController : ControllerBase
    {
        [HttpGet]
        public async Task<List<AuthenticationADGroupModal>> getADGroups()
        {
            
            ADAccessProvider accessProvider = new ADAccessProvider();
            return await accessProvider.ADGroups();

        }

    }
}
