using Workspace.Shared.Entities.WorkspaceApp;


namespace admin.workspace.Client.Services.WorkspaceAppService
{
    public interface IWsDomainService
    {
        Task<WsDomain> GetWsDomains();
    }
}
