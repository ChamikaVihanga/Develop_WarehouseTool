using System;
using System.Collections.Generic;

namespace Workspace.Shared.AuthData
{
    public partial class AuthenticationClaimRequirement
    {
        [Key]
        public int RequirementId { get; set; }
        public string? RequirementName { get; set; }
        public string Uri { get; set; }
        public bool IsActive { get; set; }
        public bool beenReviewed { get; set; }
        public string? description { get; set; }

        public int? AuthenticationHttpMethodsId { get; set; }
        public AuthenticationHttpMethod? AuthenticationHttpMethods { get; set; }

        public int? AuthenticationClaimGroupId { get; set; }
        public AuthenticationClaimGroup? AuthenticationClaimGroup { get; set; }

        public ICollection<AuthenticationClaimValue>? authenticationClaimValues { get; set; }
    }
}
