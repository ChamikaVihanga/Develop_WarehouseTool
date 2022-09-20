using System;
using System.Collections.Generic;

namespace Workspace.Shared.AuthData
{
    public partial class AuthenticationUserClaimsHolder
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<AuthenticationClaimValue>? authenticationClaimValues { get; set; }
    }
}
