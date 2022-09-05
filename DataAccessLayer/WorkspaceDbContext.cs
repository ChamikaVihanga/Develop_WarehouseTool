using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;
using Workspace.Shared.AuthData;
using Workspace.Shared.Entities.Warehouse;
using Workspace.Shared.Entities.SampleApp;
using Workspace.Shared.Entities.Readonly;

namespace DataAccessLayer
{
    public class WorkspaceDbContext : DbContext
    {
        public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options)
        {
        }


        #region ReadOnly Databases
        public DbSet<Vs_Employee> Vs_Employees { get; set; }
        public DbSet<SapEmployee> SapEmployee { get; set; }
        public DbSet<SapPlant> SapPlants { get; set; }
        public DbSet<SapWorkContract> SapWorkContracts { get; set; }
        public DbSet<SapOrganizationalUnit> SapOrganizationalUnits { get; set; }
        public DbSet<SapCostCenter> SapCostCenters { get; set; }
        #endregion ReadOnly Databases


        #region Authentication data access
        public DbSet<AuthenticationClaim> AuthenticationClaims { get; set; } = null!;
        public DbSet<AuthenticationClaimGroup> AuthenticationClaimGroups { get; set; } = null!;
        public DbSet<AuthenticationClaimRequirement> AuthenticationClaimRequirements { get; set; } = null!;
        public DbSet<AuthenticationClaimValue> AuthenticationClaimValues { get; set; } = null!;
        public DbSet<AuthenticationUserClaimsHolder> AuthenticationUserClaimsHolders { get; set; } = null!;
        public DbSet<AuthenticationHttpMethod> AuthenticationHttpMethods { get; set; } = null!;
        #endregion Authentication data access


        public DbSet<ReFaRequest> ReFaRequests { get; set; }
        public DbSet<SampleTodo> SampleTodos { get; set; }


        // warehouse data entry - efficiency 
        public DbSet<OperationRecord> OperationRecords { get; set; }
        public DbSet<OperationList> OperationLists { get; set; }
        public DbSet<VS_Employees_1> VS_Employees_1 { get; set; }
        public DbSet<OperationDetail> OperationDetails { get; set; }
        public DbSet<ShiftGroup> ShiftGroups { get; set; }
        public DbSet<WorkingShifts> WorkingShift { get; set; } 





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vs_Employee>().ToTable(nameof(Vs_Employees), t => t.ExcludeFromMigrations());
        }

    }
}

