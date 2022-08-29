using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared.AuthenticationModels
{
    public class Authentication_ClaimValue
    {
        [Key]
        public int ClaimValueId { get; set; }
        public string Value { get; set; }


        public int? Authentication_ClaimId { get; set; }
        public Authentication_Claim? Authentication_Claim { get; set; }

        

        public ICollection<Authentication_ClaimRequirement>? Authentication_ClaimsRequirements { get; set; }
        public ICollection<Authentication_ClaimGroup>? Authentication_ClaimGroups { get; set; }

        public ICollection<Authentication_UserClaimHolders>? Authentication_UserClaimsHolders { get; set; }

    }
}
