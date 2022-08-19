using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared.AuthenticationModels
{
    public class Authentication_HttpMethods
    {
        public int Id { get; set; }
        public string HttpMethod { get; set; }

        public List<Authentication_ClaimRequirement> Authentication_ClaimRequirements { get; set; }
    }
}
