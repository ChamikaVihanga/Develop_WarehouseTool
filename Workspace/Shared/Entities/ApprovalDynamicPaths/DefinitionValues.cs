using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ApprovalDynamicPaths
{
    public class DefinitionValues
    {
        [Key]
        public Guid? DefinitionValueId { get; set; }
        public string? DefinitionValue { get; set; }
        public Guid? ApprovalDefinitionId { get; set; }
        public ApprovalDefinitions? ApprovalDefinition { get; set; }
        public ICollection<ApprovalConfigurations>? ApprovalConfigurations { get; set; }
    }
}
