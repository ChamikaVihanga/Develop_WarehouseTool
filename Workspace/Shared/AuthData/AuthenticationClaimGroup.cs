using System;
using System.Collections.Generic;

namespace Workspace.Shared.AuthData
{
    public partial class AuthenticationClaimGroup
    {
        [Key]
        public int ClaimGroupId { get; set; }
        public string ClaimGroupName { get; set; }
        public bool IsActive { get; set; }


        public List<AuthenticationClaimRequirement>? AuthenticationClaimRequirement { get; set; }

        public ICollection<AuthenticationClaimValue>? AuthenticationClaimValues { get; set; }

    }
}
