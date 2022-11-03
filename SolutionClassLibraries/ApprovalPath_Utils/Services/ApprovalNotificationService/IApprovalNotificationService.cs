

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalNotificationService
{
    public interface IApprovalNotificationService
    {
        Task<ApprovalUserNotification> SetNotification(ApprovalUserNotification? Notification);
        Task<List<ApprovalUserNotification>> GetNotification();
    }
}
