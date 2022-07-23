using Workspace.Shared.Entities.Notification;

namespace Workspace.Server.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        public Task<ServiceResponse<List<Notification>>> GetNotificationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
