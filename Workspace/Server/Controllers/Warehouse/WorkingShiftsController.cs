using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public WorkingShiftsController(WorkspaceDbContext context)
        {
            _context = context;
        }
    }
}
