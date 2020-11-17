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
    public class DataTypeController : ControllerBase
    {
        private readonly DbPoolDbContext _context;

        public DataTypeController(DbPoolDbContext context)
        {
            _context = context;
        }

        // GET: api/DataType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataType>>>  GetDataType()
        {
            return await  _context.DataType.ToListAsync();
        }

        // GET: api/DataType/5
        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetDataType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataType = await _context.DataType.FindAsync(id);

            if (dataType == null)
            {
                return NotFound();
            }

            return Ok(dataType);
        }
        */
        // PUT: api/DataType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataType([FromRoute] int id, [FromBody] DataType dataType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataType.idDataType)
            {
                return BadRequest();
            }

            _context.Entry(dataType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataTypeExists(id))
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

        // POST: api/DataType
        [HttpPost]
        public async Task<IActionResult> PostDataType([FromBody] DataType dataType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataType.Add(dataType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataType", new { id = dataType.idDataType }, dataType);
        }

        // DELETE: api/DataType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataType = await _context.DataType.FindAsync(id);
            if (dataType == null)
            {
                return NotFound();
            }

            _context.DataType.Remove(dataType);
            await _context.SaveChangesAsync();

            return Ok(dataType);
        }

        private bool DataTypeExists(int id)
        {
            return _context.DataType.Any(e => e.idDataType == id);
        }
    }
}