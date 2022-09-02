using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared.AuthenticationModels
{
    public class Authentication_UserClaimHolders
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<Authentication_ClaimValue>? authentication_ClaimValues { get; set; }

    }
}
