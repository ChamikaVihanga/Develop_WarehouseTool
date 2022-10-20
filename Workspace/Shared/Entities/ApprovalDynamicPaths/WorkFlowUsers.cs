using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class WorkFlowUsers
    {
        [Key]
        public Guid? UserId { get; set; }
        public string? Username { get; set; }

        public List<ApprovalRequests>? approvalRequests { get; set; }
        public ICollection<ApprovalDestinations>? ApprovalDestinations { get; set; }
        public ICollection<RequestDestinations>? RequestDestinations { get; set; }
    }
}
