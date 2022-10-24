using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalDocuementService
{
    public class ApprovalDocuementService : IApprovalDocuementService
    {
        private readonly WorkspaceDbContext _context;

        public ApprovalDocuementService(WorkspaceDbContext context)
        {
            _context = context;
        }

        public async Task<ApprovalDocuments> AddApprovalDocument(ApprovalDocuments? Doc)
        {
            ApprovalDocuments? Document = await _context.apd_approvalDocuments.Where(a => a.DocumentName == Doc.DocumentName).FirstOrDefaultAsync();

            if (Document == null)
            {
                var result = await _context.apd_approvalDocuments.AddAsync(new ApprovalDocuments() {  DocumentName = Doc.DocumentName});
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            return Document;
        }

        public async Task<List<ApprovalDocuments>> ApprovalDocuments()
        {
            return await _context.apd_approvalDocuments.Include(a => a.PriorityIndexes).ThenInclude(a => a.ApprovalDefinition).ToListAsync();
        }
    }
}
