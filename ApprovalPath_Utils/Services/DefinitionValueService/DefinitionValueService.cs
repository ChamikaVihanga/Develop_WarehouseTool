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

        public DefinitionValueService(WorkspaceDbContext context, IApprovalDestinationPathsService approvalDestinationPathsService, IApprovalDocuementService approvalDocuementService)
        {
            _context = context;
            _approvalDestinationPathsService = approvalDestinationPathsService;
            _approvalDocuementService = approvalDocuementService;   
        }
        public async Task<DefinitionValues> GetApprovalDefinitions(Guid? id)
        {
            return await _context.apd_definitionValues.Where(a=> a.DefinitionValueId == id).Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDocuments).Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDestinations).ThenInclude(a => a.WorkFlowUsers).Include(a => a.ApprovalConfigurations).ThenInclude(a => a.ApprovalDestinations).ThenInclude(a => a.WorkFlowIndex).FirstOrDefaultAsync();
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
    }
}
