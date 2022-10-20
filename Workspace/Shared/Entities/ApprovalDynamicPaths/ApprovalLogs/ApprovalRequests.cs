using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalPath;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs
{
    public class ApprovalRequests
    {
        [Key]
        public Guid? ApprovalRequestId { get; set; }

        //Requested user
        public Guid? WorkFlowUserId { get; set; }
        public WorkFlowUsers? WorkFlowUser { get; set; }
        public Guid? ApprovalDocumentId { get; set; }
        public ApprovalDocuments? ApprovalDocument { get; set; }



    }
}
