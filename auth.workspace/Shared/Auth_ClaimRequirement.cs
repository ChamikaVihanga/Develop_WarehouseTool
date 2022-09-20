using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class Auth_ClaimRequirement
    {
        [Key]
        public int ClaimRequirementId { get; set; }
        public string ClaimRequirementName { get; set; }

        //Claim
        public int Auth_ClaimId { get; set; }
        public Auth_Claim Auth_Claim { get; set; }
        public string ValueToBeChecked { get; set; }

        
    }
}
