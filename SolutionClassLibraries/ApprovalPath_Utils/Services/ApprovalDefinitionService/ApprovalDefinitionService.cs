using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalDefinitionService
{
    public class ApprovalDefinitionService : IApprovalDefinitionService
    {
        private readonly WorkspaceDbContext _context;

        public ApprovalDefinitionService(WorkspaceDbContext context)
        {
            _context = context;
        }
        public async Task<List<ApprovalDefinitions>> GetApprovalDefinitions()
        {
            return await _context.apd_approvalDefinitions.ToListAsync();
        }
    }
}
