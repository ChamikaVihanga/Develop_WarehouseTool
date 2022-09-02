using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared.AuthenticationModels
{
    public class Authentication_Claim
    {
        [Key]
        public int ClaimId { get; set; }
        public string Claim { get; set; }
        public bool IsActive { get; set; }


        public List<Authentication_ClaimValue>? Authentication_ClaimValue { get; set; }

     
    }
}
