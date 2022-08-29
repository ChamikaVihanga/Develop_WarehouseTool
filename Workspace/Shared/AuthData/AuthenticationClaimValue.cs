using System;
using System.Collections.Generic;

namespace Workspace.Shared.AuthData
{
    public partial class AuthenticationClaimValue
    {
        [Key]
        public int ClaimValueId { get; set; }
        public string Value { get; set; }


        public int? AuthenticationClaimId { get; set; }
        public AuthenticationClaim? AuthenticationClaim { get; set; }



        public ICollection<AuthenticationClaimRequirement>? AuthenticationClaimsRequirements { get; set; }
        public ICollection<AuthenticationClaimGroup>? AuthenticationClaimGroups { get; set; }

        public ICollection<AuthenticationUserClaimsHolder>? AuthenticationUserClaimsHolders { get; set; }
    }
}
