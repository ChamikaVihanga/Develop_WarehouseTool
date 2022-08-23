using Workspace.Shared.AuthData;

namespace Workspace.Server.AuthorizationService.CustomPolicyDataProvider
{
    public interface ICustomPolicyDataProvider
    {
        Task<List<AuthenticationClaimRequirement>> getClaimRequirement(string ClaimName, string Method);
    }
}
