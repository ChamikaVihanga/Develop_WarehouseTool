using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalConfigurationManagerService
{
    public interface IApprovalConfigurationManagerService
    {
        Task<List<ApprovalConfigurations>> setConfigs(List<ApprovalConfigurations> configs);
    }
}
