using System;
using System.Collections.Generic;

namespace Workspace.Shared.Auth
{
    public partial class AuthenticationUserClaimsHolder
    {
        public AuthenticationUserClaimsHolder()
        {
            AuthenticationClaimValuesClaimValues = new HashSet<AuthenticationClaimValue>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<AuthenticationClaimValue> AuthenticationClaimValuesClaimValues { get; set; }
    }
}
