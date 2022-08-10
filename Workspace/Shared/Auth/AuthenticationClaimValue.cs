using System;
using System.Collections.Generic;

namespace Workspace.Shared.Auth
{
    public partial class AuthenticationClaimValue
    {
        public AuthenticationClaimValue()
        {
            AuthenticationClaimGroupsClaimGroups = new HashSet<AuthenticationClaimGroup>();
            AuthenticationClaimsRequirementsRequirements = new HashSet<AuthenticationClaimRequirement>();
            AuthenticationUserClaimsHoldersUsers = new HashSet<AuthenticationUserClaimsHolder>();
        }

        public int ClaimValueId { get; set; }
        public string Value { get; set; } = null!;
        public int? AuthenticationClaimId { get; set; }

        public virtual AuthenticationClaim? AuthenticationClaim { get; set; }

        public virtual ICollection<AuthenticationClaimGroup> AuthenticationClaimGroupsClaimGroups { get; set; }
        public virtual ICollection<AuthenticationClaimRequirement> AuthenticationClaimsRequirementsRequirements { get; set; }
        public virtual ICollection<AuthenticationUserClaimsHolder> AuthenticationUserClaimsHoldersUsers { get; set; }
    }
}
