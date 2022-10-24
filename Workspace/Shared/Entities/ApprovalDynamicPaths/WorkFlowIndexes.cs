using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class WorkFlowIndexes
    {
        [Key]
        public Guid? WorkFlowIndexId { get; set; }
        public int? WorkFlowIndex { get; set; }

        [JsonIgnore]
        public List<ApprovalDestinations>? ApprovalDestinations { get; set; }
        [JsonIgnore]
        public List<WorkFlowLogs>? WorkFlowLogs { get; set; }
    }
    
}
