using ApprovalPath_Utils.Services.ApprovalConfigurationManagerService;
using ApprovalPath_Utils.Services.ApprovalConfigurationService;
using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalDocuementService;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.DefinitionValueService
{
    public class DefinitionValueService : IDefinitionValueService
    {
        private readonly WorkspaceDbContext _context;
        private readonly IApprovalDestinationPathsService _approvalDestinationPathsService;
        private readonly IApprovalDocuementService _approvalDocuementService;
        private readonly IApprovalConfigurationManagerService _approvalConfigurationManagerService;
        private readonly IApprovalConfigurationService _approvalConfigurationService;


        public DefinitionValueService(WorkspaceDbContext context, IApprovalDestinationPathsService approvalDestinationPathsService, IApprovalDocuementService approvalDocuementService, IApprovalConfigurationManagerService approvalConfigurationManagerService, IApprovalConfigurationService approvalConfigurationService)
        {
            _context = context;
            _approvalDestinationPathsService = approvalDestinationPathsService;
            _approvalDocuementService = approvalDocuementService;   
            _approvalConfigurationManagerService = approvalConfigurationManagerService;
            _approvalConfigurationService = approvalConfigurationService;
        }
        public async Task<DefinitionValues> GetApprovalDefinitions(Guid? id)
        {
            return await _context.apd_definitionValues.Where(a=> a.DefinitionValueId == id)
                .Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDocuments)
                .Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDestinations).ThenInclude(a => a.WorkFlowUsers)
                .Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDestinations).ThenInclude(a => a.WorkFlowIndex)
                .Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDestinations).ThenInclude(a => a.ApprovalUserNotification).ThenInclude(a => a.WorkFlowUsers).FirstOrDefaultAsync();
        }

        
        public async Task ConfigureDefinitionValues(Guid definitionValueId, List<ApprovalConfigurations> approvalConfigurations)
        {
            List<ApprovalConfigurations> NewListConf = new List<ApprovalConfigurations>();

            foreach(ApprovalConfigurations conf in approvalConfigurations)
            {
                ApprovalConfigurations newConf = new ApprovalConfigurations();
                newConf.ApprovalConfigurationId = Guid.NewGuid();
                foreach(ApprovalDestinations? destination in conf.ApprovalDestinations)
                {
                    var result = await _approvalDestinationPathsService.createDestination(destination);
                    newConf.ApprovalDestinations.Add(result);
                }
                foreach(var doc in conf.ApprovalDocuments)
                {
                    var result = await _approvalDocuementService.AddApprovalDocument(doc);
                    newConf.ApprovalDocuments.Add(result);
                }
                NewListConf.Add(newConf);
            }


        }

        public async Task<DefinitionValues?>? SetConfiguration(Guid? id, List<ApprovalConfigurations> approvalConfigurations)
        {
            DefinitionValues? defintion  = await GetApprovalDefinitions(id);
            if (defintion != null)
            {
                defintion?.ApprovalConfigurations?.Clear();
                var newConfigList = await _approvalConfigurationManagerService.setConfigs(approvalConfigurations);
                var ListCreated =  await _approvalConfigurationService.createConfFromList(newConfigList);
                defintion.ApprovalConfigurations = ListCreated;
                var result = _context.apd_definitionValues.Update(defintion);
                await _context.SaveChangesAsync();

                return result.Entity;
            }

            return null;
           

        }
    }
}
