using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.AuthData
{
    public class AuthenticationHttpMethod
    {
        [Key]
        public int Id { get; set; }
        public string HttpMethod { get; set; }

        public List<AuthenticationClaimRequirement> AuthenticationClaimRequirements { get; set; }
    }
}
