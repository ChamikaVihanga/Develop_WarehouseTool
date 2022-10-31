using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalUserService
{
    public class ApprovalUserService : IApprovalUserService
    {

        private readonly WorkspaceDbContext _context;

        public ApprovalUserService(WorkspaceDbContext context)
        {
            _context = context;
        }

        public async Task<WorkFlowIndexes> createFlowIndex(int? flowIndex)
        {
            WorkFlowIndexes? index = await _context.apd_workFlowIndexes.Where(a => a.WorkFlowIndex == flowIndex).FirstOrDefaultAsync();

            if (index == null)
            {
                var result = await _context.apd_workFlowIndexes.AddAsync(new WorkFlowIndexes() { WorkFlowIndex = flowIndex });
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            return index;
        }
        public async Task<WorkFlowUsers> createUser(string? username)
        {
            WorkFlowUsers? user = await _context.apd_workFlowUsers.Where(a => a.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                var result = await _context.apd_workFlowUsers.AddAsync(new WorkFlowUsers() { Username = username });
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            return user;


        }
    }
}
