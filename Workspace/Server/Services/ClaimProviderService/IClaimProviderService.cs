using Workspace.Shared.AuthData;

namespace Workspace.Server.Services.ClaimProviderService
{
    public interface IClaimProviderService
    {
        Task<List<AuthenticationClaimRequirement>> GetClaims(string path, string method);
    }
}
