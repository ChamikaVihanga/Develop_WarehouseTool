using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Server.Controllers.ResourceFacilities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReFaRequests1Controller : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public ReFaRequests1Controller(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/ReFaRequests1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReFaRequest>>> GetReFaRequests()
        {
          if (_context.ReFaRequests == null)
          {
              return NotFound();
          }
            return await _context.ReFaRequests.ToListAsync();
        }

        // GET: api/ReFaRequests1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReFaRequest>> GetReFaRequest(Guid id)
        {
          if (_context.ReFaRequests == null)
          {
              return NotFound();
          }
            var reFaRequest = await _context.ReFaRequests.FindAsync(id);

            if (reFaRequest == null)
            {
                return NotFound();
            }

            return reFaRequest;
        }

        // PUT: api/ReFaRequests1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReFaRequest(Guid id, ReFaRequest reFaRequest)
        {
            if (id != reFaRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(reFaRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReFaRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReFaRequests1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReFaRequest>> PostReFaRequest(ReFaRequest reFaRequest)
        {
          if (_context.ReFaRequests == null)
          {
              return Problem("Entity set 'WorkspaceDbContext.ReFaRequests'  is null.");
          }
            _context.ReFaRequests.Add(reFaRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReFaRequest", new { id = reFaRequest.Id }, reFaRequest);
        }

        // DELETE: api/ReFaRequests1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReFaRequest(Guid id)
        {
            if (_context.ReFaRequests == null)
            {
                return NotFound();
            }
            var reFaRequest = await _context.ReFaRequests.FindAsync(id);
            if (reFaRequest == null)
            {
                return NotFound();
            }

            _context.ReFaRequests.Remove(reFaRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReFaRequestExists(Guid id)
        {
            return (_context.ReFaRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
