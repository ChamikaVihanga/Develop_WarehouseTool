using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;
using Workspace.Shared.Auth;
using Workspace.Shared.Entities.Warehouse;

namespace DataAccessLayer
{
    public class WorkspaceDbContext : DbContext
    {
        public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options)
        {
        }
        public DbSet<ReFaRequest> ReFaRequests { get; set; }


        // warehouse data entry - efficiency 
        public DbSet<OperationRecord> OperationRecords { get; set; }
        public DbSet<OperationList> OperationLists { get; set; }
        public DbSet<OperationDetaile> OperationDetailes { get; set; }
        public DbSet<VS_Employees> VS_Employees { get; set; }
        public DbSet<OperationDetail> OperationDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If DB have defferent names
            //modelBuilder.Entity<TodoItem>().ToTable("TodoItems");
            //modelBuilder.Entity<TodoList>().ToTable("TodoLists");
        }

        //public DbSet<AuthenticationClaimRequirement> authenticationClaimRequirements { get; set; }
    }

}

