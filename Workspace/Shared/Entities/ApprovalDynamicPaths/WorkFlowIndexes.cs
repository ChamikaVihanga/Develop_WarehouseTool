using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class WorkFlowIndexes
    {
        [Key]
        public Guid? WorkFlowIndexId { get; set; }
        public int? WorkFlowIndex { get; set; }
        public List<ApprovalDestinations>? ApprovalDestinations { get; set; }
        public List<WorkFlowLogs>? WorkFlowLogs { get; set; }
    }
    
}
