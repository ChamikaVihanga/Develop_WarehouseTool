using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class ApprovalUserNotification
    {
        [Key]
        public Guid? NotifyUserSetId { get; set; }

        public ICollection<WorkFlowUsers>? WorkFlowUsers { get; set; }

        public List<ApprovalDefinitions>? ApprovalDefinitions { get; set; }
    }
}
