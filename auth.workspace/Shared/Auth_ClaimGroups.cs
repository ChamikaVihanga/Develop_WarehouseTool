using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class Auth_ClaimGroups
    {
        [Key]
        public int Auth_ClaimGroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
       
    }
}
