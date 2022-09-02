

namespace admin.workspace.Server.Authorization.DataProviderInterfaces
{
    public interface ICustomClaimChecker
    {
       
        Task<List<AuthenticationClaimRequirement>> getClaimRequirement(string EndPoint, string Method, QueryString queryString);
    }
}
