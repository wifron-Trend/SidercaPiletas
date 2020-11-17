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
    public class PoolActionHistoryController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PoolActionHistoryController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/PoolActionHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoolActionHistory>>>  GetPoolActionHistory()
        {
            return await _context.PoolActionHistory.ToListAsync();
        }

        // GET: api/PoolActionHistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoolActionHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolActionHistory = await _context.PoolActionHistory.FindAsync(id);

            if (poolActionHistory == null)
            {
                return NotFound();
            }

            return Ok(poolActionHistory);
        }

        // PUT: api/PoolActionHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoolActionHistory([FromRoute] int id, [FromBody] PoolActionHistory poolActionHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poolActionHistory.idPoolActionHistory)
            {
                return BadRequest();
            }

            _context.Entry(poolActionHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolActionHistoryExists(id))
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

        // POST: api/PoolActionHistory
        [HttpPost]
        public async Task<IActionResult> PostPoolActionHistory([FromBody] PoolActionHistory poolActionHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PoolActionHistory.Add(poolActionHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoolActionHistory", new { id = poolActionHistory.idPoolActionHistory }, poolActionHistory);
        }

        // DELETE: api/PoolActionHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoolActionHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolActionHistory = await _context.PoolActionHistory.FindAsync(id);
            if (poolActionHistory == null)
            {
                return NotFound();
            }

            _context.PoolActionHistory.Remove(poolActionHistory);
            await _context.SaveChangesAsync();

            return Ok(poolActionHistory);
        }

        private bool PoolActionHistoryExists(int id)
        {
            return _context.PoolActionHistory.Any(e => e.idPoolActionHistory == id);
        }
    }
}