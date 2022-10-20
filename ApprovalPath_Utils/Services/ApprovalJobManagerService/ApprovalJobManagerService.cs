using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalJobManagerService
{
    public class ApprovalJobManagerService : IApprovalJobManagerService
    {
        private readonly WorkspaceDbContext _context;

        public ApprovalJobManagerService(WorkspaceDbContext context)
        {
            _context = context;
        }
        public async Task<ApprovalConfigurations?>? CreateJob(Guid Doc, ClaimsPrincipal User)
        {
            List<Claim> claims = new List<Claim>();
            foreach (Claim claim in User.Claims)
            {
                claims.Add(claim);
            }

            var Definitions = await setPriority(Doc);

            foreach(var Definition in Definitions)
            {
                Claim? claim = User.FindFirst(Definition.ApprovalDefinition);
                if (claim != null)
                {
                    ApprovalDefinitions? approvalDefinition = await _context.apd_approvalDefinitions.Where(a => a.ApprovalDefinitionId == Definition.ApprovalDefinitionId).Include(a => a.DefinitionValues).FirstOrDefaultAsync();
                    if(approvalDefinition.DefinitionValues.Any(a => a.DefinitionValue == claim.Value))
                    {
                        DefinitionValues value = _context.apd_definitionValues.Where(a => a.DefinitionValue == claim.Value)
                            .Include(a => a.ApprovalConfigurations)
                            .ThenInclude(a => a.ApprovalDocuments)
                            .Include(a => a.ApprovalConfigurations)
                            .ThenInclude(a => a.ApprovalDestinations)
                            .ThenInclude(a => a.WorkFlowUsers)
                            .Include(a => a.ApprovalConfigurations)
                            .ThenInclude(a => a.ApprovalDestinations)
                            .ThenInclude(a => a.WorkFlowIndex)
                            .FirstOrDefault();
                        foreach(ApprovalConfigurations? approvalConfiguration in value.ApprovalConfigurations)
                        {
                            if(approvalConfiguration.ApprovalDocuments.Any(a => a.ApprovalDocumentId == Doc))
                            {
                                return approvalConfiguration;
                            }
                        }
                    }

                }

            }

            return null;
        } 

        private async Task<List<ApprovalDefinitions?>>? setPriority(Guid Doc)
        {
            var order = await _context.apd_priorityIndexes.Where(a => a.ApprovalDocumentId == Doc).Include(a => a.ApprovalDefinition).OrderBy(a => a.PriorityIndex).Select(a => a.ApprovalDefinition).ToListAsync();
            return order;
        }

     

      


    }
}
