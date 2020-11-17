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
    public class PropertyController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public PropertyController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Property
        [HttpGet]
        public IEnumerable<Property> GetProperty()
        {
            return _context.Property;
        }

        // GET: api/Property/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @property = await _context.Property.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return Ok(@property);
        }

        // PUT: api/Property/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty([FromRoute] int id, [FromBody] Property @property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @property.idProperty)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Property
        [HttpPost]
        public async Task<IActionResult> PostProperty([FromBody] Property @property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Property.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = @property.idProperty }, @property);
        }

        // DELETE: api/Property/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @property = await _context.Property.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Property.Remove(@property);
            await _context.SaveChangesAsync();

            return Ok(@property);
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.idProperty == id);
        }
    }
}