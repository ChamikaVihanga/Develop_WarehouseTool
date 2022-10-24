using Workspace.Shared;
using Workspace.Shared.Entities.Notification;

namespace WorkspaceServices.NotificationService
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationsAsync();
    }
}
