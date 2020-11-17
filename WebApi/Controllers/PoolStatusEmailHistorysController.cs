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
    public class PoolStatusEmailHistorysController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PoolStatusEmailHistorysController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/PoolStatusEmailHistorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoolStatusEmailHistory>>> GetPoolStatusEmailHistory()
        {
            return await _context.PoolStatusEmailHistory.ToListAsync();
        }

        // GET: api/PoolStatusEmailHistorys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoolStatusEmailHistory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolStatusEmailHistory = await _context.PoolStatusEmailHistory.FindAsync(id);

            if (poolStatusEmailHistory == null)
            {
                return NotFound();
            }

            return Ok(poolStatusEmailHistory);
        }

        // PUT: api/PoolStatusEmailHistorys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoolStatusEmailHistory([FromRoute] long id, [FromBody] PoolStatusEmailHistory poolStatusEmailHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poolStatusEmailHistory.idPoolStatusEmailHistory)
            {
                return BadRequest();
            }

            _context.Entry(poolStatusEmailHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolStatusEmailHistoryExists(id))
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

        // POST: api/PoolStatusEmailHistorys
        [HttpPost]
        public async Task<IActionResult> PostPoolStatusEmailHistory([FromBody] PoolStatusEmailHistory poolStatusEmailHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PoolStatusEmailHistory.Add(poolStatusEmailHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoolStatusEmailHistory", new { id = poolStatusEmailHistory.idPoolStatusEmailHistory }, poolStatusEmailHistory);
        }

        // DELETE: api/PoolStatusEmailHistorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoolStatusEmailHistory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolStatusEmailHistory = await _context.PoolStatusEmailHistory.FindAsync(id);
            if (poolStatusEmailHistory == null)
            {
                return NotFound();
            }

            _context.PoolStatusEmailHistory.Remove(poolStatusEmailHistory);
            await _context.SaveChangesAsync();

            return Ok(poolStatusEmailHistory);
        }

        private bool PoolStatusEmailHistoryExists(long id)
        {
            return _context.PoolStatusEmailHistory.Any(e => e.idPoolStatusEmailHistory == id);
        }
    }
}