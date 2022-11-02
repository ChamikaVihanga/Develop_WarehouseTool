using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalDestinationPathsService
{
    public interface IApprovalDestinationPathsService
    {
        Task<List<ApprovalDestinations>> GetDestinations();

        Task<ApprovalDestinations> createDestination(ApprovalDestinations? approvalDestination);


    }
}
