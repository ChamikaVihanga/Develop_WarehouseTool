using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;
using Workspace.Shared.AuthData;
using Workspace.Shared.Entities.Warehouse;
using Workspace.Shared.Entities.SampleApp;
using Workspace.Shared.Entities.Readonly;
using Workspace.Shared.Entities.ApprovalPath;
using Workspace.Shared.Entities.ApprovalDynamicPaths;
using Workspace.Shared.Entities.ApprovalDynamicPaths.ApprovalLogs;

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
        public DbSet<AuthenticationADAssignedGroup> AuthenticationADAssignedGroups { get; set; } = null!;


        #endregion Authentication data access


        public DbSet<ReFaRequest> ReFaRequests { get; set; }
        public DbSet<SampleTodo> SampleTodos { get; set; }


        #region warehouse data entry - efficiency 
        public DbSet<Warehouse_OperationRecord> Warehouse_OperationRecords { get; set; }
        public DbSet<Warehouse_OperationList> Warehouse_OperationLists { get; set; }        
        public DbSet<Warehouse_OperationDetail> Warehouse_OperationDetails { get; set; }       
        public DbSet<Warehouse_WorkingShift> Warehouse_WorkingShifts { get; set; }
        #endregion


        #region Approval path

        public DbSet<RegisteredDocuments> ap_registeredDocuments { get; set; }
        public DbSet<ApprovalPathUsers> ap_approvalPathUsers { get; set; }
        public DbSet<UserBased_Config> ap_userBased_Configs { get; set; }
        public DbSet<ApprovalFlowOrder> ap_approvalFlowOrder { get; set; }
        public DbSet<NotifiedUserSets> ap_userSetsToNotify { get; set; }
        public DbSet<ApprovalRequest> ap_approvalRequests { get; set; }



        #endregion Approval path

        #region Approval path -Dynamic

        public DbSet<ApprovalConfigurations>  apd_approvalConfigurations { get; set; }
        public DbSet<ApprovalDefinitions>  apd_approvalDefinitions { get; set; }
        public DbSet<DefinitionValues>  apd_definitionValues { get; set; }
        public DbSet<ApprovalDestinations>  apd_approvalDestinations { get; set; }
        public DbSet<ApprovalDocuments>  apd_approvalDocuments { get; set; }
        public DbSet<WorkFlowIndexes>  apd_workFlowIndexes { get; set; }
        public DbSet<WorkFlowUsers>  apd_workFlowUsers { get; set; }
        public DbSet<PriorityIndexes> apd_priorityIndexes { get; set; }

        #region Approval Logs

        public DbSet<ApprovalRequests> apd_approvalRequests { get; set; }
        public DbSet<RequestDestinations> apd_requestDestinations { get; set; }
        public DbSet<WorkFlowLogs> apd_workFlowLogs { get; set; }


        #endregion Approval Logs



        #endregion Approval path -Dynamic


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vs_Employee>().ToTable(nameof(Vs_Employees), t => t.ExcludeFromMigrations());



            #region Authentication data Seeding
            modelBuilder.Entity<AuthenticationHttpMethod>().HasData(
                 new { Id = 1, HttpMethod = "GET" },
                 new { Id = 2, HttpMethod = "POST" },
                 new { Id = 3, HttpMethod = "PUT" },
                 new { Id = 4, HttpMethod = "DELETE" },
                 new { Id = 5, HttpMethod = "PATCH" }
                 );
            #endregion Authentication data Seeding
        }

    }
}

