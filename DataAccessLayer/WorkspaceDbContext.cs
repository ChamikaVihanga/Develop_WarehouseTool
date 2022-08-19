using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;
using Workspace.Shared.AuthData;

namespace DataAccessLayer
{
    public class WorkspaceDbContext : DbContext
    {
        public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options)
        {
        }

        public DbSet<ReFaRequest> ReFaRequests { get; set; }
       

        //Authentication data access
        public DbSet<AuthenticationClaim> AuthenticationClaims { get; set; } = null!;
        public DbSet<AuthenticationClaimGroup> AuthenticationClaimGroups { get; set; } = null!;
        public DbSet<AuthenticationClaimRequirement> AuthenticationClaimRequirements { get; set; } = null!;
        public DbSet<AuthenticationClaimValue> AuthenticationClaimValues { get; set; } = null!;
        public DbSet<AuthenticationUserClaimsHolder> AuthenticationUserClaimsHolders { get; set; } = null!;
        public DbSet<AuthenticationHttpMethod> AuthenticationHttpMethods { get; set; } = null!;
    }

  
}
