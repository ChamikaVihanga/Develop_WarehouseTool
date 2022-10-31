using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using ApprovalPath_Utils.Services.ApprovalNotificationService;
using ApprovalPath_Utils.Services.ApprovalUserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APD_DestinationController : ControllerBase
    {
        
        private IApprovalDestinationPathsService _approvalDestinationPathsService;
        private IApprovalNotificationService _approvalNotificationService;
        private IApprovalUserService _approvalUserService;


        public APD_DestinationController(IApprovalDestinationPathsService approvalPath, IApprovalNotificationService approvalNotificationService, IApprovalUserService approvalUserService)
        {
            _approvalDestinationPathsService = approvalPath;
            _approvalNotificationService = approvalNotificationService;
            _approvalUserService = approvalUserService;
        }

        [HttpGet]
        public async Task<List<ApprovalDestinations>> Get()
        {
            return await _approvalDestinationPathsService.GetDestinations();
        }

        [HttpPost]
        public async Task<WorkFlowUsers> createUser(string? username)
        {
            WorkFlowUsers? user = await _approvalUserService.createUser(username);
            return user;
        }

        [HttpPost]
        public async Task<ApprovalDestinations> createDestination(ApprovalDestinations? username)
        {
            ApprovalDestinations? ApprovalDestination = await _approvalDestinationPathsService.createDestination(username);
            return ApprovalDestination;
        }
        [HttpGet]
        public Task<List<ApprovalUserNotification>> GetNotificationsUsers()
        {
            return _approvalNotificationService.GetNotification();
        }

        [HttpPost]
        public Task<ApprovalUserNotification> createNotificationUsers(ApprovalUserNotification? approvalUserNotification)
        {
            return _approvalNotificationService.SetNotification(approvalUserNotification);
        }
    }
}
