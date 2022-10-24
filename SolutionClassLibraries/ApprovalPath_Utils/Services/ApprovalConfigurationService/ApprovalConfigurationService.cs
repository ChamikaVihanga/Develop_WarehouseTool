using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;
using System.Text.Json;
using Microsoft.Extensions.Primitives;
using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalDocuementService;

namespace ApprovalPath_Utils.Services.ApprovalConfigurationService
{
    public class ApprovalConfigurationService : IApprovalConfigurationService
    {
        private readonly WorkspaceDbContext _context;
        private readonly IApprovalDestinationPathsService _approvalDestinationPathsService;
        private readonly IApprovalDocuementService _approvalDocuementService;

        public ApprovalConfigurationService(WorkspaceDbContext context, IApprovalDestinationPathsService approvalDestinationPathsService, IApprovalDocuementService approvalDocuementService)
        {
            _context = context;
            _approvalDestinationPathsService = approvalDestinationPathsService;
            _approvalDocuementService = approvalDocuementService;
        }

        public async Task<List<ApprovalConfigurations>> GetApprovalConfigurationsAsync()
        {
            return await _context.apd_approvalConfigurations
                .Include(a => a.ApprovalDestinations).ThenInclude(a =>a .WorkFlowIndex)
                .Include(a => a.ApprovalDestinations).ThenInclude(a =>a .WorkFlowUsers)
                .Include(a => a.ApprovalDocuments)
                .ToListAsync();
        }
        public async Task<ApprovalConfigurations> CreateConfig(ApprovalConfigurations approvalConfiguration)
        {
            //var approvalConfigurations = await _context.apd_approvalConfigurations.Include(a => a.ApprovalDestinations).ThenInclude(a => a.WorkFlowUsers).Include(a => a.ApprovalDocuments).ToListAsync();
            var approvalConfigurations = await GetApprovalConfigurationsAsync();


            ApprovalConfigurations config = new ApprovalConfigurations();

            List<ApprovalDestinations> approvalDestinations = new List<ApprovalDestinations>();
            List<ApprovalDocuments> approvalDocuments = new List<ApprovalDocuments>();



            //test destinations
            foreach (ApprovalDestinations approvalDestination in approvalConfiguration.ApprovalDestinations)
            {
                var destination = await _approvalDestinationPathsService.createDestination(approvalDestination);
                approvalDestinations.Add(destination);

            }

            foreach (ApprovalDocuments approvalDocument in approvalConfiguration.ApprovalDocuments)
            {
                var Docuemnt = await _approvalDocuementService.AddApprovalDocument(approvalDocument);
                approvalDocuments.Add(Docuemnt);  
            }


            foreach(var conf in approvalConfigurations)
            {
                var ConfDestination = conf.ApprovalDestinations.OrderBy(a =>a.ApprovalDestinationId);
                var RequestedDestination = approvalDestinations.OrderBy(a => a.ApprovalDestinationId);

                var ConfDocs = conf.ApprovalDocuments.OrderBy(a => a.ApprovalDocumentId);
                var RequestedDocs = approvalDocuments.OrderBy(a => a.ApprovalDocumentId);

                if (ConfDestination.SequenceEqual(RequestedDestination) && ConfDocs.SequenceEqual(RequestedDocs))
                {
                    return conf;
                }
             
            }
            var result = await _context.apd_approvalConfigurations.AddAsync(new ApprovalConfigurations() { DisplayName = approvalConfiguration.DisplayName, ApprovalDocuments = approvalDocuments, ApprovalDestinations = approvalDestinations });
            await _context.SaveChangesAsync();
            return result.Entity;


            //ApprovalDestinations? approvalDestinations = await _context.apd_approvalDestinations.Where(a => a == approvalConfiguration.ApprovalDestinations).FirstOrDefaultAsync();
            //foreach(ApprovalDestinations? destination in approvalConfiguration.ApprovalDestinations) 
            //{
            //    ApprovalDestinations? approvalDestination = await _context.apd_approvalDestinations.Where(a => a.WorkFlowUsers == destination.WorkFlowUsers && a.WorkFlowIndex.WorkFlowIndex == destination.WorkFlowIndex.WorkFlowIndex).FirstOrDefaultAsync();
            //    if(approvalDestination != null)
            //    {

            //    }
            //}

        }
        



    }
}

