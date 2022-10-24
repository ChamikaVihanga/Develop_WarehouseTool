using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalPath
{
    public class ApprovalRequest
    {
        [Key]
        public Guid? ApprovalRequestId { get; set; }

        public Guid? approvalPathUserId { get; set; }
        public ApprovalPathUsers? approvalPathUser { get; set; }

        public Guid? registeredDocumentId { get; set; }
        public RegisteredDocuments? registeredDocument { get; set; }

        public bool IsPending { get; set; }
    }
}
