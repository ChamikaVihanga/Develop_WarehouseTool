global using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;

namespace Workspace.Shared.AuthData
{
    public partial class AuthenticationClaim
    {
        [Key]
        public int ClaimId { get; set; }
        public string Claim { get; set; }
        public bool IsActive { get; set; }


        public List<AuthenticationClaimValue>? AuthenticationClaimValues { get; set; }
    }
}
