
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
            List<AuthenticationADGroupModal> authenticationADGroupModals = new List<AuthenticationADGroupModal>();
            using (var context = new PrincipalContext(ContextType.Domain, "VSAG.CH", "lkittrainee01", "Sl@987654321"))
            {
                GroupPrincipal groupPrincipal = new GroupPrincipal(context);
                PrincipalSearcher searcher = new PrincipalSearcher(groupPrincipal);
                
                foreach(var group in searcher.FindAll())
                {
                    authenticationADGroupModals.Add(new AuthenticationADGroupModal() { 
                        GroupName = group.Name,
                        guid = group.Guid 
                    });
                }
            }
            return authenticationADGroupModals;

        }

    }
}
