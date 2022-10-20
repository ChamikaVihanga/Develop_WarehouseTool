using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class ApprovalConfigurations
    {
        [Key]
        public Guid? ApprovalConfigurationId { get; set; }

        
        public string? DisplayName { get; set; }

        public ICollection<DefinitionValues>? DefinitionValues { get; set; }

        
        public virtual ICollection<ApprovalDocuments>? ApprovalDocuments { get; set; }

        
        public ICollection<ApprovalDestinations>? ApprovalDestinations { get; set; }

    

    }
}
