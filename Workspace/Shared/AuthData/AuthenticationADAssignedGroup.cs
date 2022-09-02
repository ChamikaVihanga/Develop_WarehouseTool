using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.AuthData
{
    public class AuthenticationADAssignedGroup
    {
        public int id { get; set; }
        public  Guid ADGroupGuid { get; set; }

        public ICollection<AuthenticationClaimRequirement> authenticationClaimRequirements { get; set; }
    }
}
