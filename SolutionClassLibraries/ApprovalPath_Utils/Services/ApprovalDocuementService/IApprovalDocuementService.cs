using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalDocuementService
{
    public interface IApprovalDocuementService 
    {
        Task<List<ApprovalDocuments>> ApprovalDocuments();
        Task<ApprovalDocuments> AddApprovalDocument(ApprovalDocuments Doc);
    }
}
