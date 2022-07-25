namespace Workspace.Server.Authentication.CustomClaims
{
    public interface ICustomClaim
    {
        List<Authentication_ClaimRequirement> getClaimRequirement(string ClaimName);
    }
}
