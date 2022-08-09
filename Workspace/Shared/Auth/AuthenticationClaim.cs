using System;
using System.Collections.Generic;

namespace Workspace.Shared.Auth
{
    public partial class AuthenticationClaim
    {
        public AuthenticationClaim()
        {
            AuthenticationClaimValues = new HashSet<AuthenticationClaimValue>();
        }

        public int ClaimId { get; set; }
        public string Claim { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<AuthenticationClaimValue> AuthenticationClaimValues { get; set; }
    }
}
