using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Workspace.Shared.Auth
{
    public partial class AuthenticationHandlerDb3Context : DbContext
    {
        public AuthenticationHandlerDb3Context()
        {
        }

        public AuthenticationHandlerDb3Context(DbContextOptions<AuthenticationHandlerDb3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthenticationClaim> AuthenticationClaims { get; set; } = null!;
        public virtual DbSet<AuthenticationClaimGroup> AuthenticationClaimGroups { get; set; } = null!;
        public virtual DbSet<AuthenticationClaimRequirement> AuthenticationClaimRequirements { get; set; } = null!;
        public virtual DbSet<AuthenticationClaimValue> AuthenticationClaimValues { get; set; } = null!;
        public virtual DbSet<AuthenticationUserClaimsHolder> AuthenticationUserClaimsHolders { get; set; } = null!;
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=wssrl03;Database=AuthenticationHandlerDb3;User Id=sa;Password=12QWaszx12QWaszx;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
            modelBuilder.Entity<AuthenticationClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("authentication_Claims");
            });

            modelBuilder.Entity<AuthenticationClaimGroup>(entity =>
            {
                entity.HasKey(e => e.ClaimGroupId);

                entity.ToTable("authentication_ClaimGroups");

                entity.HasMany(d => d.AuthenticationClaimValuesClaimValues)
                    .WithMany(p => p.AuthenticationClaimGroupsClaimGroups)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthenticationClaimGroupAuthenticationClaimValue",
                        l => l.HasOne<AuthenticationClaimValue>().WithMany().HasForeignKey("AuthenticationClaimValuesClaimValueId"),
                        r => r.HasOne<AuthenticationClaimGroup>().WithMany().HasForeignKey("AuthenticationClaimGroupsClaimGroupId"),
                        j =>
                        {
                            j.HasKey("AuthenticationClaimGroupsClaimGroupId", "AuthenticationClaimValuesClaimValueId");

                            j.ToTable("Authentication_ClaimGroupAuthentication_ClaimValue");

                            j.HasIndex(new[] { "AuthenticationClaimValuesClaimValueId" }, "IX_Authentication_ClaimGroupAuthentication_ClaimValue_Authentication_ClaimValuesClaimValueId");

                            j.IndexerProperty<int>("AuthenticationClaimGroupsClaimGroupId").HasColumnName("Authentication_ClaimGroupsClaimGroupId");

                            j.IndexerProperty<int>("AuthenticationClaimValuesClaimValueId").HasColumnName("Authentication_ClaimValuesClaimValueId");
                        });
            });

            modelBuilder.Entity<AuthenticationClaimRequirement>(entity =>
            {
                entity.HasKey(e => e.RequirementId);

                entity.ToTable("authentication_ClaimRequirements");

                entity.HasIndex(e => e.AuthenticationClaimGroupId, "IX_authentication_ClaimRequirements_Authentication_ClaimGroupId");

                entity.Property(e => e.AuthenticationClaimGroupId).HasColumnName("Authentication_ClaimGroupId");

                entity.HasOne(d => d.AuthenticationClaimGroup)
                    .WithMany(p => p.AuthenticationClaimRequirements)
                    .HasForeignKey(d => d.AuthenticationClaimGroupId);

                entity.HasMany(d => d.AuthenticationClaimValuesClaimValues)
                    .WithMany(p => p.AuthenticationClaimsRequirementsRequirements)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthenticationClaimRequirementAuthenticationClaimValue",
                        l => l.HasOne<AuthenticationClaimValue>().WithMany().HasForeignKey("AuthenticationClaimValuesClaimValueId"),
                        r => r.HasOne<AuthenticationClaimRequirement>().WithMany().HasForeignKey("AuthenticationClaimsRequirementsRequirementId").HasConstraintName("FK_Authentication_ClaimRequirementAuthentication_ClaimValue_authentication_ClaimRequirements_Authentication_ClaimsRequirementsR~"),
                        j =>
                        {
                            j.HasKey("AuthenticationClaimsRequirementsRequirementId", "AuthenticationClaimValuesClaimValueId");

                            j.ToTable("Authentication_ClaimRequirementAuthentication_ClaimValue");

                            j.HasIndex(new[] { "AuthenticationClaimValuesClaimValueId" }, "IX_Authentication_ClaimRequirementAuthentication_ClaimValue_authentication_ClaimValuesClaimValueId");

                            j.IndexerProperty<int>("AuthenticationClaimsRequirementsRequirementId").HasColumnName("Authentication_ClaimsRequirementsRequirementId");

                            j.IndexerProperty<int>("AuthenticationClaimValuesClaimValueId").HasColumnName("authentication_ClaimValuesClaimValueId");
                        });
            });

            modelBuilder.Entity<AuthenticationClaimValue>(entity =>
            {
                entity.HasKey(e => e.ClaimValueId);

                entity.ToTable("authentication_ClaimValues");

                entity.HasIndex(e => e.AuthenticationClaimId, "IX_authentication_ClaimValues_Authentication_ClaimId");

                entity.Property(e => e.AuthenticationClaimId).HasColumnName("Authentication_ClaimId");

                entity.HasOne(d => d.AuthenticationClaim)
                    .WithMany(p => p.AuthenticationClaimValues)
                    .HasForeignKey(d => d.AuthenticationClaimId);
            });

            modelBuilder.Entity<AuthenticationUserClaimsHolder>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("authentication_UserClaimsHolders");

                entity.HasMany(d => d.AuthenticationClaimValuesClaimValues)
                    .WithMany(p => p.AuthenticationUserClaimsHoldersUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthenticationClaimValueAuthenticationUserClaimHolder",
                        l => l.HasOne<AuthenticationClaimValue>().WithMany().HasForeignKey("AuthenticationClaimValuesClaimValueId"),
                        r => r.HasOne<AuthenticationUserClaimsHolder>().WithMany().HasForeignKey("AuthenticationUserClaimsHoldersUserId").HasConstraintName("FK_Authentication_ClaimValueAuthentication_UserClaimHolders_authentication_UserClaimsHolders_Authentication_UserClaimsHoldersUs~"),
                        j =>
                        {
                            j.HasKey("AuthenticationUserClaimsHoldersUserId", "AuthenticationClaimValuesClaimValueId");

                            j.ToTable("Authentication_ClaimValueAuthentication_UserClaimHolders");

                            j.HasIndex(new[] { "AuthenticationClaimValuesClaimValueId" }, "IX_Authentication_ClaimValueAuthentication_UserClaimHolders_authentication_ClaimValuesClaimValueId");

                            j.IndexerProperty<int>("AuthenticationUserClaimsHoldersUserId").HasColumnName("Authentication_UserClaimsHoldersUserId");

                            j.IndexerProperty<int>("AuthenticationClaimValuesClaimValueId").HasColumnName("authentication_ClaimValuesClaimValueId");
                        });
            });


           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
