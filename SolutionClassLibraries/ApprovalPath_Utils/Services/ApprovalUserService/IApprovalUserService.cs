using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalUserService
{
    public interface IApprovalUserService
    {


        Task<WorkFlowIndexes> createFlowIndex(int? flowIndex);
        Task<WorkFlowUsers> createUser(string? username);
    }
}
