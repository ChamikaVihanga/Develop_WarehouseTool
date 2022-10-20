using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalJobManagerService
{
    public interface IApprovalJobManagerService 
    {
        Task<ApprovalConfigurations?>? CreateJob(Guid Doc, ClaimsPrincipal User);
    }
 
}
