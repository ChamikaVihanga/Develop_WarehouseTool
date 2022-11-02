using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class ApprovalDestinations
    {
        [Key]
        public Guid? ApprovalDestinationId { get; set; }
        public Guid? WorkFlowIndexId { get; set; }
        public WorkFlowIndexes? WorkFlowIndex { get; set; }

        public ICollection<WorkFlowUsers>? WorkFlowUsers { get; set; }

        [JsonIgnore]
        public ICollection<ApprovalConfigurations>? ApprovalConfigurations { get; set; }

        public Guid? ApprovalUserNotificationId { get; set; }
        public ApprovalUserNotification? ApprovalUserNotification { get; set; }

        
    }
}
