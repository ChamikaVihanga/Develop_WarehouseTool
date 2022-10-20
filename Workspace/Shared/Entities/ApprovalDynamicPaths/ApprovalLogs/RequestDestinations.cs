using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs
{
    public class RequestDestinations
    {
        [Key]
        public Guid? RequestDestinationId { get; set; }
        public Guid? WorkFlowLogId { get; set; }   
        public WorkFlowLogs? WorkFlowLog { get; set; }

        public ICollection<WorkFlowUsers>? WorkFlowUsers { get; set; }   
        public bool HasCompleted { get; set; }
    }
}
 