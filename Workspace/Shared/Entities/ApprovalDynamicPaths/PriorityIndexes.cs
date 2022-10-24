using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class PriorityIndexes
    {
        [Key]
        public Guid? PriorityIndexId { get; set; }
        public int? PriorityIndex { get; set; }

        public Guid? ApprovalDefinitionId { get; set; }
        public ApprovalDefinitions? ApprovalDefinition { get; set; }

        public Guid? ApprovalDocumentId { get; set; }
        public ApprovalDocuments? ApprovalDocument { get; set; }
    }
}
