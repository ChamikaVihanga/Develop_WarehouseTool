using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared.AuthenticationModels
{
    public class Authentication_ClaimRequirement
    {
        [Key]
        public int RequirementId { get; set; }
        public string? RequirementName { get; set; }
        public string Uri { get; set; }
        public bool IsActive { get; set; }
        public bool beenReviewed { get; set; }
        public string? description { get; set; }    

        public int? Authentication_HttpMethodsId { get; set; }
        public Authentication_HttpMethods Authentication_HttpMethod { get; set; }

        public int? Authentication_ClaimGroupId { get; set; }
        public Authentication_ClaimGroup? Authentication_ClaimGroup { get; set; }

        public ICollection<Authentication_ClaimValue>? authentication_ClaimValues { get; set; }

       


    }
} 
