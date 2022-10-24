using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs
{
    public class WorkFlowLogs
    {
        [Key]
        public Guid? WorkFlowLogId { get; set; }
        
        public Guid? ApprovalRequestId { get; set; }
        public ApprovalRequests? ApprovalRequest { get; set; }

        public Guid WorkFlowIndexId { get; set; }
        public WorkFlowIndexes? WorkFlowIndex { get; set; }   


        public bool HasApproved { get; set; }
        public List<RequestDestinations>? RequestDestinations { get; set; }

    }

}
