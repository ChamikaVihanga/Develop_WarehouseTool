using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalPath
{
    public class RegisteredDocuments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? id { get; set; }
        public string? DocumentName { get; set; }

        public ICollection<UserBased_Config>? UserBased_Configs { get; set; }
        public ICollection<ApprovalRequest>? ApprovalRequests { get; set; }
    }
}
