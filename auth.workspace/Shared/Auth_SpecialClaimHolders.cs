using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class Auth_SpecialClaimHolders
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<Auth_UserGroups> UserGroups { get; set; }
        
    }
}
