using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalPath
{
    public class NotifiedUserSets
    {
        [Key]
        public Guid? NotifyUserSetId { get; set; }
        public ICollection<ApprovalPathUsers>? approvalPathUsers { get; set;}    


    }
}
