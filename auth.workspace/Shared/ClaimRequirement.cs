using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class ClaimRequirement
    {
        public int id { get; set; }
        public string RequirementName { get; set; }
        public string ClaimsRequired { get; set; }
        public string ValueRequired { get; set; }   
        public bool IsRequired { get; set; }

    }
}
