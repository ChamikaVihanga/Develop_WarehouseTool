using ApprovalPath_Utils.Services.ApprovalNotificationService;
using ApprovalPath_Utils.Services.ApprovalUserService;
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
        private readonly IApprovalNotificationService _approvalNotificationService;
        private readonly IApprovalUserService _approvalUserService;


        public ApprovalDestinationPathsService(WorkspaceDbContext context, IApprovalNotificationService approvalNotificationService, IApprovalUserService approvalUserService)
        {
            _context = context;
            _approvalNotificationService = approvalNotificationService;
            _approvalUserService = approvalUserService;
        }


        public async Task<List<ApprovalDestinations>> GetDestinations()
        {
            var approvalDestinations = await _context.apd_approvalDestinations.Include(a => a.WorkFlowUsers).Include(a => a.WorkFlowIndex).Include(a => a.ApprovalUserNotification).ThenInclude(a => a.WorkFlowUsers).ToListAsync();
            return approvalDestinations;
        }

        public async Task<ApprovalDestinations> createDestination(ApprovalDestinations? approvalDestination)
        {
            //var selected = approvalDestination.WorkFlowUsers.Select(a => a.Username.ToLower()).ToList();
            var destinations = await _context.apd_approvalDestinations.Include(a => a.WorkFlowUsers).Include(a => a.WorkFlowIndex).Include(a => a.ApprovalUserNotification).ThenInclude(a => a.WorkFlowUsers).ToListAsync();
            ApprovalDestinations? destination = new ApprovalDestinations();

            List<WorkFlowUsers> workFlowUsers = new List<WorkFlowUsers>();

            foreach (ApprovalDestinations des in destinations)
            {
                var a = des.WorkFlowUsers.Select(a =>a.Username.ToLower()).OrderBy(a =>a).ToList();
                var b = approvalDestination.WorkFlowUsers.Select(a => a.Username.ToLower()).OrderBy(a => a).ToList();

                List<WorkFlowUsers>? DestinationWFU = des.ApprovalUserNotification?.WorkFlowUsers?.ToList();
                List<WorkFlowUsers>? Requested = approvalDestination.ApprovalUserNotification?.WorkFlowUsers?.ToList();

                List<string>? DestinationWFUStr = new List<string>();
                List<string>? RequestedStr = new List<string>();

                if (DestinationWFU != null)
                {
                    DestinationWFUStr = DestinationWFU.Select(a => a.Username).OrderBy(a => a).ToList();
                    
                }
                if(Requested != null)
                {
                    RequestedStr = Requested.Select(a => a.Username).OrderBy(a => a).ToList();
                }



                if (a.SequenceEqual(b)  && approvalDestination.WorkFlowIndex.WorkFlowIndex == des.WorkFlowIndex.WorkFlowIndex)
                {
                    if(DestinationWFU == null && RequestedStr.Count == 0 || DestinationWFUStr.SequenceEqual(RequestedStr))
                    {
                        destination = des;
                        return destination;
                    }
                   
                }
            }

            if(destination.ApprovalDestinationId == null)
            {
                
                foreach(var user in approvalDestination.WorkFlowUsers)
                {
                    if(user.Username != null)
                    {
                        var flowUser = await _approvalUserService.createUser(user.Username);
                        workFlowUsers.Add(flowUser);
                    }
                    
                }

                if (approvalDestination.WorkFlowIndex.WorkFlowIndex is not null)
                {
                    destination.WorkFlowIndex = await _approvalUserService.createFlowIndex(approvalDestination.WorkFlowIndex.WorkFlowIndex);
                }
                
                if(approvalDestination.ApprovalUserNotification is not null)
                {
                    destination.ApprovalUserNotification = await _approvalNotificationService.SetNotification(approvalDestination.ApprovalUserNotification);
                }
         
                destination.WorkFlowUsers = workFlowUsers;
                var result = await _context.apd_approvalDestinations.AddAsync(destination);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return destination;
        }

        

    }
}
