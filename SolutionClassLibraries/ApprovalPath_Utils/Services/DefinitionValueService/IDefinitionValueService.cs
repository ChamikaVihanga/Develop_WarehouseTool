using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.DefinitionValueService
{
    public interface IDefinitionValueService
    {
        Task<DefinitionValues> GetApprovalDefinitions(Guid? id);
        Task<DefinitionValues> SetConfiguration(Guid? id, List<ApprovalConfigurations> approvalConfigurations);
    }
}
