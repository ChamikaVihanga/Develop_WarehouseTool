using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class Auth_Claim
    {
   
        [Key]
        public int Auth_ClaimId { get; set; }
        public string Claim { get; set; }
        public bool IsActive { get; set; }
      
        public ICollection<Auth_ClaimRequirement> auth_ClaimRequirement { get; set; }
    }
}
