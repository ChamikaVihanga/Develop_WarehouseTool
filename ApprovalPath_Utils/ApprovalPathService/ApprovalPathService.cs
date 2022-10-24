using ApprovalPath_Utils.Services.ApprovalConfigurationService;
using ApprovalPath_Utils.Services.ApprovalDefinitionService;
using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalDocuementService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using ApprovalPath_Utils.Services.DefinitionValueService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.ApprovalPathService
{
    public static class ApprovalPathService
    {
        public static void AddApprovalPathProvider(this IServiceCollection services)
        {
            services.AddScoped<IApprovalJobManagerService, ApprovalJobManagerService>();
            services.AddScoped<IApprovalDocuementService, ApprovalDocuementService>();
            services.AddScoped<IApprovalDestinationPathsService, ApprovalDestinationPathsService>();
            services.AddScoped<IApprovalConfigurationService, ApprovalConfigurationService>();
            services.AddScoped<IApprovalDefinitionService, ApprovalDefinitionService>();
            services.AddScoped<IDefinitionValueService, DefinitionValueService>();
        }
    }
}
