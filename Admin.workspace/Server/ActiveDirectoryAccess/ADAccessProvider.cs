using System.DirectoryServices.AccountManagement;

namespace admin.workspace.Server.ActiveDirectoryAccess
{
    public class ADAccessProvider
    {
        public PrincipalContext _principalContext { get; set; }
        public ADAccessProvider()
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "VSAG.CH", "lkittrainee01", "Sl@987654321");
            _principalContext = principalContext;
        }

        public async Task<List<AuthenticationADGroupModal>> ADGroups()
        {
            List<AuthenticationADGroupModal> authenticationADGroupModals = new List<AuthenticationADGroupModal>();
            GroupPrincipal groups = new GroupPrincipal(_principalContext);
            PrincipalSearcher searcher = new PrincipalSearcher(groups);

            foreach (var group in searcher.FindAll())
            {
                authenticationADGroupModals.Add(new AuthenticationADGroupModal()
                {
                    GroupName = group.Name,
                    guid = group.Guid
                });
            }
            return authenticationADGroupModals;
        }

        public async Task<bool> checkName(string username)
        {
            using (var user = UserPrincipal.FindByIdentity(_principalContext, IdentityType.SamAccountName, username))
            {
                if(user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }
    }
}
