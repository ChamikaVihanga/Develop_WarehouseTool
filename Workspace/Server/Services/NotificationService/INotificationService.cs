using Workspace.Shared.Entities.Notification;

namespace Workspace.Server.Services.NotificationService
{
    public interface INotificationService
    {
        Task<ServiceResponse<List<Notification>>> GetNotificationsAsync();
    }
}
