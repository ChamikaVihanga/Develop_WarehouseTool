﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(WorkspaceDbContext))]
    partial class WorkspaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthenticationClaimGroupAuthenticationClaimValue", b =>
                {
                    b.Property<int>("AuthenticationClaimGroupsClaimGroupId")
                        .HasColumnType("int");

                    b.Property<int>("AuthenticationClaimValuesClaimValueId")
                        .HasColumnType("int");

                    b.HasKey("AuthenticationClaimGroupsClaimGroupId", "AuthenticationClaimValuesClaimValueId");

                    b.HasIndex("AuthenticationClaimValuesClaimValueId");

                    b.ToTable("AuthenticationClaimGroupAuthenticationClaimValue");
                });

            modelBuilder.Entity("AuthenticationClaimRequirementAuthenticationClaimValue", b =>
                {
                    b.Property<int>("AuthenticationClaimsRequirementsRequirementId")
                        .HasColumnType("int");

                    b.Property<int>("authenticationClaimValuesClaimValueId")
                        .HasColumnType("int");

                    b.HasKey("AuthenticationClaimsRequirementsRequirementId", "authenticationClaimValuesClaimValueId");

                    b.HasIndex("authenticationClaimValuesClaimValueId");

                    b.ToTable("AuthenticationClaimRequirementAuthenticationClaimValue");
                });

            modelBuilder.Entity("AuthenticationClaimValueAuthenticationUserClaimsHolder", b =>
                {
                    b.Property<int>("AuthenticationUserClaimsHoldersUserId")
                        .HasColumnType("int");

                    b.Property<int>("authenticationClaimValuesClaimValueId")
                        .HasColumnType("int");

                    b.HasKey("AuthenticationUserClaimsHoldersUserId", "authenticationClaimValuesClaimValueId");

                    b.HasIndex("authenticationClaimValuesClaimValueId");

                    b.ToTable("AuthenticationClaimValueAuthenticationUserClaimsHolder");
                });

            modelBuilder.Entity("ShiftGroupVS_Employees_1", b =>
                {
                    b.Property<int>("VS_EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("shiftGroupsId")
                        .HasColumnType("int");

                    b.HasKey("VS_EmployeesId", "shiftGroupsId");

                    b.HasIndex("shiftGroupsId");

                    b.ToTable("ShiftGroupVS_Employees_1");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaim", b =>
                {
                    b.Property<int>("ClaimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimId"), 1L, 1);

                    b.Property<string>("Claim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ClaimId");

                    b.ToTable("AuthenticationClaims");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaimGroup", b =>
                {
                    b.Property<int>("ClaimGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimGroupId"), 1L, 1);

                    b.Property<string>("ClaimGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ClaimGroupId");

                    b.ToTable("AuthenticationClaimGroups");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaimRequirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequirementId"), 1L, 1);

                    b.Property<int?>("AuthenticationClaimGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("AuthenticationHttpMethodsId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RequirementName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("beenReviewed")
                        .HasColumnType("bit");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequirementId");

                    b.HasIndex("AuthenticationClaimGroupId");

                    b.HasIndex("AuthenticationHttpMethodsId");

                    b.ToTable("AuthenticationClaimRequirements");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaimValue", b =>
                {
                    b.Property<int>("ClaimValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimValueId"), 1L, 1);

                    b.Property<int?>("AuthenticationClaimId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClaimValueId");

                    b.HasIndex("AuthenticationClaimId");

                    b.ToTable("AuthenticationClaimValues");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationHttpMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HttpMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationHttpMethods");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationUserClaimsHolder", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AuthenticationUserClaimsHolders");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.ResourceFacilities.ReFaRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestedFor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReFaRequests");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.SampleApp.SampleTodo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SampleTodos");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationListId")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Target")
                        .HasColumnType("int");

                    b.Property<string>("TimePeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TimeSpan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationListId");

                    b.ToTable("OperationDetails");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationLists");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Achivement")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Efficiency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OperationListId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VS_EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationListId");

                    b.HasIndex("VS_EmployeesId");

                    b.ToTable("OperationRecords");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.ShiftGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkingShiftId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkingShiftsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkingShiftsId");

                    b.ToTable("ShiftGroups");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.VS_Employees_1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationalUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VS_Employees_1");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.WorkingShifts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShiftTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkingShift");
                });

            modelBuilder.Entity("AuthenticationClaimGroupAuthenticationClaimValue", b =>
                {
                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaimGroup", null)
                        .WithMany()
                        .HasForeignKey("AuthenticationClaimGroupsClaimGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaimValue", null)
                        .WithMany()
                        .HasForeignKey("AuthenticationClaimValuesClaimValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthenticationClaimRequirementAuthenticationClaimValue", b =>
                {
                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaimRequirement", null)
                        .WithMany()
                        .HasForeignKey("AuthenticationClaimsRequirementsRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaimValue", null)
                        .WithMany()
                        .HasForeignKey("authenticationClaimValuesClaimValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthenticationClaimValueAuthenticationUserClaimsHolder", b =>
                {
                    b.HasOne("Workspace.Shared.AuthData.AuthenticationUserClaimsHolder", null)
                        .WithMany()
                        .HasForeignKey("AuthenticationUserClaimsHoldersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaimValue", null)
                        .WithMany()
                        .HasForeignKey("authenticationClaimValuesClaimValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShiftGroupVS_Employees_1", b =>
                {
                    b.HasOne("Workspace.Shared.Entities.Warehouse.VS_Employees_1", null)
                        .WithMany()
                        .HasForeignKey("VS_EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workspace.Shared.Entities.Warehouse.ShiftGroup", null)
                        .WithMany()
                        .HasForeignKey("shiftGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaimRequirement", b =>
                {
                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaimGroup", "AuthenticationClaimGroup")
                        .WithMany("AuthenticationClaimRequirement")
                        .HasForeignKey("AuthenticationClaimGroupId");

                    b.HasOne("Workspace.Shared.AuthData.AuthenticationHttpMethod", "AuthenticationHttpMethods")
                        .WithMany("AuthenticationClaimRequirements")
                        .HasForeignKey("AuthenticationHttpMethodsId");

                    b.Navigation("AuthenticationClaimGroup");

                    b.Navigation("AuthenticationHttpMethods");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaimValue", b =>
                {
                    b.HasOne("Workspace.Shared.AuthData.AuthenticationClaim", "AuthenticationClaim")
                        .WithMany("AuthenticationClaimValues")
                        .HasForeignKey("AuthenticationClaimId");

                    b.Navigation("AuthenticationClaim");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationDetail", b =>
                {
                    b.HasOne("Workspace.Shared.Entities.Warehouse.OperationList", "OperationList")
                        .WithMany("OperationDetails")
                        .HasForeignKey("OperationListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationList");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationRecord", b =>
                {
                    b.HasOne("Workspace.Shared.Entities.Warehouse.OperationList", "OperationList")
                        .WithMany("OperationRecords")
                        .HasForeignKey("OperationListId");

                    b.HasOne("Workspace.Shared.Entities.Warehouse.VS_Employees_1", "VS_Employees")
                        .WithMany("OperationRecords")
                        .HasForeignKey("VS_EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationList");

                    b.Navigation("VS_Employees");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.ShiftGroup", b =>
                {
                    b.HasOne("Workspace.Shared.Entities.Warehouse.WorkingShifts", "WorkingShifts")
                        .WithMany("ShiftGroups")
                        .HasForeignKey("WorkingShiftsId");

                    b.Navigation("WorkingShifts");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaim", b =>
                {
                    b.Navigation("AuthenticationClaimValues");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationClaimGroup", b =>
                {
                    b.Navigation("AuthenticationClaimRequirement");
                });

            modelBuilder.Entity("Workspace.Shared.AuthData.AuthenticationHttpMethod", b =>
                {
                    b.Navigation("AuthenticationClaimRequirements");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationList", b =>
                {
                    b.Navigation("OperationDetails");

                    b.Navigation("OperationRecords");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.VS_Employees_1", b =>
                {
                    b.Navigation("OperationRecords");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.WorkingShifts", b =>
                {
                    b.Navigation("ShiftGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
