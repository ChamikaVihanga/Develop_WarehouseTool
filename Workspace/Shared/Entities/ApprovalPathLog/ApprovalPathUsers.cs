using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalPath
{
    public class ApprovalPathUsers
    {
      
        [Key]
        public Guid? Id { get; set; } = new Guid();
        public string? UserName { get; set; }

        public ICollection<ApprovalFlowOrder>? ApprovalFlowOrders { get; set; }
        public ICollection<NotifiedUserSets>? userSetsToNotifiy { get; set; }
        public ICollection<ApprovalRequest>? approvalRequests { get; set; }

    }
}
