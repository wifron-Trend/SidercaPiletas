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
    public class EmailTypeController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public EmailTypeController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/EmailType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailType>>>  GetEmailType()
        {
            return await _context.EmailType.ToListAsync();
        }

        // GET: api/EmailType/5
        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetEmailType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailType = await _context.EmailType.FindAsync(id);

            if (emailType == null)
            {
                return NotFound();
            }

            return Ok(emailType);
        }
        */
        // PUT: api/EmailType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailType([FromRoute] int id, [FromBody] EmailType emailType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailType.idEmailType)
            {
                return BadRequest();
            }

            _context.Entry(emailType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailTypeExists(id))
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

        // POST: api/EmailType
        [HttpPost]
        public async Task<IActionResult> PostEmailType([FromBody] EmailType emailType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmailType.Add(emailType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailType", new { id = emailType.idEmailType }, emailType);
        }

        // DELETE: api/EmailType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailType = await _context.EmailType.FindAsync(id);
            if (emailType == null)
            {
                return NotFound();
            }

            _context.EmailType.Remove(emailType);
            await _context.SaveChangesAsync();

            return Ok(emailType);
        }

        private bool EmailTypeExists(int id)
        {
            return _context.EmailType.Any(e => e.idEmailType == id);
        }
    }
}