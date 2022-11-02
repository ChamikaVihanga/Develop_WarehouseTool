using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public ICollection<ApprovalDestinations>? ApprovalDestinations { get; set; }
        public ICollection<RequestDestinations>? RequestDestinations { get; set; }
        public ICollection<ApprovalUserNotification>? ApprovalUserNotifications { get; set; }
    }
}
