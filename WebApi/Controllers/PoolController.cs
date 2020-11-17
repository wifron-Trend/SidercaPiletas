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
    public class PoolController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PoolController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Pool
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pool>>>  GetPool()
        {
            return await _context.Pool.ToListAsync();
        }

        // GET: api/Pool/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pool = await _context.Pool.FindAsync(id);

            if (pool == null)
            {
                return NotFound();
            }

            return Ok(pool);
        }

        // PUT: api/Pool/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPool([FromRoute] int id, [FromBody] Pool pool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pool.idPool)
            {
                return BadRequest();
            }

            _context.Entry(pool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolExists(id))
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

        // POST: api/Pool
        [HttpPost]
        public async Task<IActionResult> PostPool([FromBody] Pool pool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pool.Add(pool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPool", new { id = pool.idPool }, pool);
        }

        // DELETE: api/Pool/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pool = await _context.Pool.FindAsync(id);
            if (pool == null)
            {
                return NotFound();
            }

            _context.Pool.Remove(pool);
            await _context.SaveChangesAsync();

            return Ok(pool);
        }

        private bool PoolExists(int id)
        {
            return _context.Pool.Any(e => e.idPool == id);
        }
    }
}