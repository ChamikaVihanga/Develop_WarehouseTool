using ApprovalPath_Utils.Services.ApprovalUserService;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalPriorityIndexService
{
    public class ApprovalPriorityIndexService : IApprovalPriorityIndexService
    {
        private readonly WorkspaceDbContext _context;

        public ApprovalPriorityIndexService(WorkspaceDbContext context)
        {
            _context = context;
        }

        public async Task<List<PriorityIndexes>> GetByDocument(Guid? guid)
        {
            return await _context.apd_priorityIndexes.Where(a => a.ApprovalDocumentId == guid).Include(a =>a.ApprovalDefinition).ToListAsync();
        }
    }
}
