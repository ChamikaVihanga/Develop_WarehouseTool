using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalConfigurationService
{
    public interface IApprovalConfigurationService
    {
        Task<List<ApprovalConfigurations>> GetApprovalConfigurationsAsync();
        Task<ApprovalConfigurations> CreateConfig(ApprovalConfigurations approvalConfigurations);

       
    }
}
