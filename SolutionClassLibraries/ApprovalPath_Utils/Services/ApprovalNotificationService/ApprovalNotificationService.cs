using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalUserService;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalNotificationService
{
    public class ApprovalNotificationService : IApprovalNotificationService
    {

        private readonly WorkspaceDbContext _context;
        private readonly IApprovalUserService _approvalUserService;

        public ApprovalNotificationService(WorkspaceDbContext context, IApprovalUserService approvalUserService)
        {
            _context = context;
            _approvalUserService = approvalUserService;
        }

        public async Task<ApprovalUserNotification> SetNotification(ApprovalUserNotification? Notification)
        {
            List<WorkFlowUsers> workFlowUsers = new List<WorkFlowUsers>();
            
            if(Notification.WorkFlowUsers is not null)
            {
                foreach (var user in Notification.WorkFlowUsers)
                {
                    var actualUser = await _approvalUserService.createUser(user.Username);
                    workFlowUsers.Add(actualUser);
                }
            }
            

            List<ApprovalUserNotification> approvalUserNotifications = await _context.apd_approvalUserNotification.Include(a => a.WorkFlowUsers).ToListAsync();

            ApprovalUserNotification? userNotification = approvalUserNotifications.Where(a => a.WorkFlowUsers.OrderBy(a => a.UserId).SequenceEqual(workFlowUsers.OrderBy(a => a.UserId))).FirstOrDefault();


            if (userNotification == null)
            {
                var result =  _context.apd_approvalUserNotification.Add(new ApprovalUserNotification() { NotifyUserSetId = Guid.NewGuid(), WorkFlowUsers = workFlowUsers});
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            return userNotification;
        }
        public async Task<List<ApprovalUserNotification>> GetNotification()
        {
            return await _context.apd_approvalUserNotification.Include(a => a.WorkFlowUsers).ToListAsync();
        }

    }
}
