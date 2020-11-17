using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusEmailTypeController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public StatusEmailTypeController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/StatusEmailType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusEmailType>>>  GetStatusEmailType()
        {
            return await _context.StatusEmailType.ToArrayAsync();
        }

        // GET: api/StatusEmailType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusEmailType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusEmailType = await _context.StatusEmailType.FindAsync(id);

            if (statusEmailType == null)
            {
                return NotFound();
            }

            return Ok(statusEmailType);
        }

        // PUT: api/StatusEmailType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusEmailType([FromRoute] long id, [FromBody] StatusEmailType statusEmailType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusEmailType.idStatusEmailType)
            {
                return BadRequest();
            }

            _context.Entry(statusEmailType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEmailTypeExists(id))
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

        // POST: api/StatusEmailType
        [HttpPost]
        public async Task<IActionResult> PostStatusEmailType([FromBody] StatusEmailType statusEmailType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StatusEmailType.Add(statusEmailType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusEmailType", new { id = statusEmailType.idStatusEmailType }, statusEmailType);
        }

        // DELETE: api/StatusEmailType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusEmailType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusEmailType = await _context.StatusEmailType.FindAsync(id);
            if (statusEmailType == null)
            {
                return NotFound();
            }

            _context.StatusEmailType.Remove(statusEmailType);
            await _context.SaveChangesAsync();

            return Ok(statusEmailType);
        }

        private bool StatusEmailTypeExists(long id)
        {
            return _context.StatusEmailType.Any(e => e.idStatusEmailType == id);
        }
    }
}