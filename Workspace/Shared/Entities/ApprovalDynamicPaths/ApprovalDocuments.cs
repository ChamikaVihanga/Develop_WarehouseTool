using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class ApprovalDocuments
    {
        [Key]
        public Guid? ApprovalDocumentId { get; set; }
        public string? DocumentName { get; set; }


       [JsonIgnore]
        public ICollection<ApprovalConfigurations>? ApprovalConfigurations { get; set; }
        public ICollection<PriorityIndexes>? PriorityIndexes { get; set; }
    }
}
