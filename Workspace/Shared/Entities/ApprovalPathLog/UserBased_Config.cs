using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalPath
{
    public class UserBased_Config
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? Conf_Id { get; set; }


        
        //which user belongs to the config
        public Guid? approvalPathUserId { get; set; }
        public ApprovalPathUsers? approvalPathUser { get; set; }

        public Guid? RegisteredDocumentId { get; set; }
        public RegisteredDocuments? RegisteredDocument { get; set; }

        public ICollection<ApprovalFlowOrder>? approvalFlows { get; set; }


    }
}
