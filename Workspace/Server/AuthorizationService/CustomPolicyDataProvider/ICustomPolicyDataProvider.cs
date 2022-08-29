using Workspace.Shared.AuthData;

namespace Workspace.Server.AuthorizationService.CustomPolicyDataProvider
{
    public interface ICustomPolicyDataProvider
    {
        List<AuthenticationClaimRequirement> getClaimRequirement(string ClaimName);
    }
}
