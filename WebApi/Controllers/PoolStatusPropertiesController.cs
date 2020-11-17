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
    public class PoolStatusPropertiesController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PoolStatusPropertiesController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/PoolStatusProperties
        [HttpGet]
        public IEnumerable<PoolStatusProperties> GetPoolStatusProperties()
        {
            return _context.PoolStatusProperties;
        }

        // GET: api/PoolStatusProperties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoolStatusProperties([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolStatusProperties = await _context.PoolStatusProperties.FindAsync(id);

            if (poolStatusProperties == null)
            {
                return NotFound();
            }

            return Ok(poolStatusProperties);
        }

        // PUT: api/PoolStatusProperties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoolStatusProperties([FromRoute] int id, [FromBody] PoolStatusProperties poolStatusProperties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poolStatusProperties.idStatus)
            {
                return BadRequest();
            }

            _context.Entry(poolStatusProperties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolStatusPropertiesExists(id))
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

        // POST: api/PoolStatusProperties
        [HttpPost]
        public async Task<IActionResult> PostPoolStatusProperties([FromBody] PoolStatusProperties poolStatusProperties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PoolStatusProperties.Add(poolStatusProperties);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoolStatusProperties", new { id = poolStatusProperties.idStatus }, poolStatusProperties);
        }

        // DELETE: api/PoolStatusProperties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoolStatusProperties([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poolStatusProperties = await _context.PoolStatusProperties.FindAsync(id);
            if (poolStatusProperties == null)
            {
                return NotFound();
            }

            _context.PoolStatusProperties.Remove(poolStatusProperties);
            await _context.SaveChangesAsync();

            return Ok(poolStatusProperties);
        }

        private bool PoolStatusPropertiesExists(int id)
        {
            return _context.PoolStatusProperties.Any(e => e.idStatus == id);
        }
    }
}