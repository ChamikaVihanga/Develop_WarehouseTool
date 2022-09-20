using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftGroupController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public ShiftGroupController(WorkspaceDbContext context)
        {
            _context = context;
        }
    }
}
