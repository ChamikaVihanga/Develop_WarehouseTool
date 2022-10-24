using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalPath
{
    public class ApprovalFlowOrder
    {
   
        [Key]
        public Guid? Id { get; set; } = new Guid();

        public int FlowNumber { get; set; }
        public ICollection<ApprovalPathUsers>? ApprovalPathUsers { get; set; }

        public ICollection<UserBased_Config>? userBased_Configs { get; set; }

        public Guid? notifiedUserSetsId { get; set; }
        public NotifiedUserSets? notifiedUserSet { get; set; }


    }
}
