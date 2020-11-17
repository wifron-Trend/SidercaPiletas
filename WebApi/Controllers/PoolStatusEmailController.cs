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
    public class PoolStatusEmailController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PoolStatusEmailController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/PoolStatusEmail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoolStatusEmail>>>  GetPoolStatusEmail()
        {
            return await _context.PoolStatusEmail.ToListAsync();
        }

        // GET: api/PoolStatusEmail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoolStatusEmail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolStatusEmail = await _context.PoolStatusEmail.FindAsync(id);

            if (poolStatusEmail == null)
            {
                return NotFound();
            }

            return Ok(poolStatusEmail);
        }

        // PUT: api/PoolStatusEmail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoolStatusEmail([FromRoute] int id, [FromBody] PoolStatusEmail poolStatusEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poolStatusEmail.idPool)
            {
                return BadRequest();
            }

            _context.Entry(poolStatusEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolStatusEmailExists(id))
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

        // POST: api/PoolStatusEmail
        [HttpPost]
        public async Task<IActionResult> PostPoolStatusEmail([FromBody] PoolStatusEmail poolStatusEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PoolStatusEmail.Add(poolStatusEmail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoolStatusEmail", new { id = poolStatusEmail.idPool }, poolStatusEmail);
        }

        // DELETE: api/PoolStatusEmail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoolStatusEmail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolStatusEmail = await _context.PoolStatusEmail.FindAsync(id);
            if (poolStatusEmail == null)
            {
                return NotFound();
            }

            _context.PoolStatusEmail.Remove(poolStatusEmail);
            await _context.SaveChangesAsync();

            return Ok(poolStatusEmail);
        }

        private bool PoolStatusEmailExists(int id)
        {
            return _context.PoolStatusEmail.Any(e => e.idPool == id);
        }
    }
}