global using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class Auth_UserGroups
    {
        [Key]
        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Auth_SpecialClaimHolders> Auth_SpecialClaimHolders { get; set; }
    }
}
