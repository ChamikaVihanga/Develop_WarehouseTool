using System;
using System.Collections.Generic;

namespace Workspace.Shared.Auth
{
    public partial class AuthenticationClaimGroup
    {
        public AuthenticationClaimGroup()
        {
            AuthenticationClaimRequirements = new HashSet<AuthenticationClaimRequirement>();
            AuthenticationClaimValuesClaimValues = new HashSet<AuthenticationClaimValue>();
        }

        public int ClaimGroupId { get; set; }
        public string ClaimGroupName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<AuthenticationClaimRequirement> AuthenticationClaimRequirements { get; set; }

        public virtual ICollection<AuthenticationClaimValue> AuthenticationClaimValuesClaimValues { get; set; }
    }
}
