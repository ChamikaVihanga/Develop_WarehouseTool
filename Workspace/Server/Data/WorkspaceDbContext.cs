using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Server.Data
{
    public class WorkspaceDbContext : DbContext
    {
        public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options)
        {
        }

        public DbSet<ReFaRequest> ReFaRequests { get; set; }
    }
}
