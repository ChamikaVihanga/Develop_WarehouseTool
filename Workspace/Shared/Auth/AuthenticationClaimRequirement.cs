using System;
using System.Collections.Generic;

namespace Workspace.Shared.Auth
{
    public partial class AuthenticationClaimRequirement
    {
        public AuthenticationClaimRequirement()
        {
            AuthenticationClaimValuesClaimValues = new HashSet<AuthenticationClaimValue>();
        }

        public int RequirementId { get; set; }
        public string RequirementName { get; set; } = null!;
        public bool IsActive { get; set; }
        public int? AuthenticationClaimGroupId { get; set; }

        public virtual AuthenticationClaimGroup? AuthenticationClaimGroup { get; set; }

        public virtual ICollection<AuthenticationClaimValue> AuthenticationClaimValuesClaimValues { get; set; }
    }
}
