using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class ApprovalDefinitions
    {
        [Key]
        public Guid? ApprovalDefinitionId { get; set; }
        public string? ApprovalDefinition { get; set; }
        public List<DefinitionValues>? DefinitionValues { get; set; }
        public List<PriorityIndexes>? PriorityIndexes { get; set; }

        
    }
}
