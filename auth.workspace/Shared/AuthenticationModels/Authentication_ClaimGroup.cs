using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared.AuthenticationModels
{
    public class Authentication_ClaimGroup
    {
        [Key]
        public int ClaimGroupId { get; set; }
        public string ClaimGroupName { get; set; }
        public bool IsActive { get; set; }

        
        public List<Authentication_ClaimRequirement>? Authentication_ClaimRequirement { get; set; }

        public ICollection<Authentication_ClaimValue>? Authentication_ClaimValues { get; set; }

    }
}
