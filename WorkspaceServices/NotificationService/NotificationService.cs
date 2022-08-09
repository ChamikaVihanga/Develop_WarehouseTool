using Workspace.Shared;
using Workspace.Shared.Entities.Notification;

namespace WorkspaceServices.NotificationService
{
    public class NotificationService : INotificationService
    {
        public Task<ServiceResponse<List<Notification>>> GetNotificationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
