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
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.VS_Employees", b =>
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

                    b.ToTable("VS_Employees");
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

                    b.HasOne("Workspace.Shared.Entities.Warehouse.VS_Employees", "VS_Employees")
                        .WithMany("OperationRecords")
                        .HasForeignKey("VS_EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationList");

                    b.Navigation("VS_Employees");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.OperationList", b =>
                {
                    b.Navigation("OperationDetails");

                    b.Navigation("OperationRecords");
                });

            modelBuilder.Entity("Workspace.Shared.Entities.Warehouse.VS_Employees", b =>
                {
                    b.Navigation("OperationRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
