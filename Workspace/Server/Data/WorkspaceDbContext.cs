using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;
using Workspace.Shared.Entities.Warehouse;

namespace Workspace.Server.Data
{
    public class WorkspaceDbContext : DbContext
    {
        public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options)
        {

        }
        public DbSet<ReFaRequest> ReFaRequests { get; set; }
        public DbSet<OperationRecord> OperationRecords { get; set; }
        public DbSet<OperationList> OperationLists { get; set; }
        public DbSet<OperationDetaile> OperationDetailes { get; set; }
        public DbSet<VS_Employees> VS_Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<VS_Employees>().ToTable(nameof(VS_Employees), t => t.ExcludeFromMigrations());*/
            // If DB have defferent names
            //modelBuilder.Entity<TodoItem>().ToTable("TodoItems");
            //modelBuilder.Entity<TodoList>().ToTable("TodoLists");

        }

    }
}
