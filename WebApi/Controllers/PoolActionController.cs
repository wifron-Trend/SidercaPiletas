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
    public class PoolActionController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PoolActionController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/PoolAction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoolAction>>>   GetPoolAction()
        {
            return await _context.PoolAction.ToListAsync();
        }

        // GET: api/PoolAction/5
        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetPoolAction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolAction = await _context.PoolAction.FindAsync(id);

            if (poolAction == null)
            {
                return NotFound();
            }

            return Ok(poolAction);
        }*/

        // PUT: api/PoolAction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoolAction([FromRoute] int id, [FromBody] PoolAction poolAction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poolAction.idPool)
            {
                return BadRequest();
            }

            _context.Entry(poolAction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolActionExists(id))
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

        // POST: api/PoolAction
        [HttpPost]
        public async Task<IActionResult> PostPoolAction([FromBody] PoolAction poolAction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PoolAction.Add(poolAction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoolAction", new { id = poolAction.idPool }, poolAction);
        }

        // DELETE: api/PoolAction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoolAction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolAction = await _context.PoolAction.FindAsync(id);
            if (poolAction == null)
            {
                return NotFound();
            }

            _context.PoolAction.Remove(poolAction);
            await _context.SaveChangesAsync();

            return Ok(poolAction);
        }

        private bool PoolActionExists(int id)
        {
            return _context.PoolAction.Any(e => e.idPool == id);
        }
    }
}