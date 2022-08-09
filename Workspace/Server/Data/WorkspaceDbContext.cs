﻿using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ResourceFacilities;
using Workspace.Shared.Auth;

namespace Workspace.Server.Data
{
    public class WorkspaceDbContext : DbContext
    {
        public WorkspaceDbContext(DbContextOptions<WorkspaceDbContext> options) : base(options)
        {
        }

        public DbSet<ReFaRequest> ReFaRequests { get; set; }
        public DbSet<AuthenticationClaimRequirement> authenticationClaimRequirements { get; set; }
    }

  
}
