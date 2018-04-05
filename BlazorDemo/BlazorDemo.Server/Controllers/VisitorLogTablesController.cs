using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorDemo.Shared;

namespace BlazorDemo.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/VisitorLogTables")]
    public class VisitorLogTablesController : Controller
    {
        private readonly DevDatabaseContext _context;

        public VisitorLogTablesController(DevDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/VisitorLogTables
        [HttpGet]
        public IEnumerable<VisitorLogTable> GetVisitorLogTable()
        {
            return _context.VisitorLogTable;
        }

        // GET: api/VisitorLogTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitorLogTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var visitorLogTable = await _context.VisitorLogTable.SingleOrDefaultAsync(m => m.Id == id);

            if (visitorLogTable == null)
            {
                return NotFound();
            }

            return Ok(visitorLogTable);
        }

        // PUT: api/VisitorLogTables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitorLogTable([FromRoute] int id, [FromBody] VisitorLogTable visitorLogTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitorLogTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitorLogTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorLogTableExists(id))
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

        // POST: api/VisitorLogTables
        [HttpPost]
        public async Task<IActionResult> PostVisitorLogTable([FromBody] VisitorLogTable visitorLogTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VisitorLogTable.Add(visitorLogTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisitorLogTableExists(visitorLogTable.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVisitorLogTable", new { id = visitorLogTable.Id }, visitorLogTable);
        }

        // DELETE: api/VisitorLogTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitorLogTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var visitorLogTable = await _context.VisitorLogTable.SingleOrDefaultAsync(m => m.Id == id);
            if (visitorLogTable == null)
            {
                return NotFound();
            }

            _context.VisitorLogTable.Remove(visitorLogTable);
            await _context.SaveChangesAsync();

            return Ok(visitorLogTable);
        }

        private bool VisitorLogTableExists(int id)
        {
            return _context.VisitorLogTable.Any(e => e.Id == id);
        }
    }
}