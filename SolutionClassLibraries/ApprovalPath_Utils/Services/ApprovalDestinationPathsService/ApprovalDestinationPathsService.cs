using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.AuthData;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalDestinationPathsService
{
    public class ApprovalDestinationPathsService : IApprovalDestinationPathsService
    {

        private readonly WorkspaceDbContext _context;

        public ApprovalDestinationPathsService(WorkspaceDbContext context)
        {
            _context = context;
        }


        public async Task<List<ApprovalDestinations>> GetDestinations()
        {
            var approvalDestinations = await _context.apd_approvalDestinations.Include(a => a.WorkFlowUsers).Include(a => a.WorkFlowIndex).ToListAsync();
            return approvalDestinations;
        }

        public async Task<ApprovalDestinations> createDestination(ApprovalDestinations? approvalDestination)
        {
            var selected = approvalDestination.WorkFlowUsers.Select(a => a.Username).ToList();
            var destinations = await _context.apd_approvalDestinations.Include(a => a.WorkFlowUsers).Include(a => a.WorkFlowIndex).ToListAsync();
            ApprovalDestinations? destination = new ApprovalDestinations();

            List<WorkFlowUsers> workFlowUsers = new List<WorkFlowUsers>();

            foreach (ApprovalDestinations des in destinations)
            {
                var a = des.WorkFlowUsers.Select(a =>a.Username).OrderBy(a =>a).ToList();
                var b = approvalDestination.WorkFlowUsers.Select(a => a.Username).OrderBy(a => a).ToList();
               
                if (a.SequenceEqual(b) && approvalDestination.WorkFlowIndex.WorkFlowIndex == des.WorkFlowIndex.WorkFlowIndex)
                {
                    destination = des;
                    return destination;
                }
            }

            if(destination.ApprovalDestinationId == null)
            {
                
                foreach(var user in approvalDestination.WorkFlowUsers)
                {
                    var flowUser = await createUser(user.Username);
                    workFlowUsers.Add(flowUser);
                }
                destination.WorkFlowIndex = await createFlowIndex(approvalDestination.WorkFlowIndex.WorkFlowIndex);
                destination.WorkFlowUsers = workFlowUsers;
                var result = await _context.apd_approvalDestinations.AddAsync(destination);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return destination;
        }

        public async Task<WorkFlowIndexes> createFlowIndex(int? flowIndex)
        {
            WorkFlowIndexes? index = await _context.apd_workFlowIndexes.Where(a => a.WorkFlowIndex == flowIndex).FirstOrDefaultAsync();

            if (index == null)
            {
                var result = await _context.apd_workFlowIndexes.AddAsync(new WorkFlowIndexes() {  WorkFlowIndex = flowIndex });
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
