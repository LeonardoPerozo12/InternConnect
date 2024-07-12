using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternConnect.Context;
using InternConnect.Models;

namespace InternConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasantiasController : ControllerBase
    {
        private readonly InternConnectContext _context;

        public PasantiasController(InternConnectContext context)
        {
            _context = context;
        }

        // GET: api/Pasantias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasantia>>> GetPasantias()
        {
            return await _context.Pasantias.ToListAsync();
        }

        // GET: api/Pasantias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasantia>> GetPasantia(int id)
        {
            var pasantia = await _context.Pasantias.FindAsync(id);

            if (pasantia == null)
            {
                return NotFound();
            }

            return pasantia;
        }

        // PUT: api/Pasantias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasantia(int id, Pasantia pasantia)
        {
            if (id != pasantia.IDPasantia)
            {
                return BadRequest();
            }

            _context.Entry(pasantia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasantiaExists(id))
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

        // POST: api/Pasantias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasantia>> PostPasantia(Pasantia pasantia)
        {
            _context.Pasantias.Add(pasantia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasantia", new { id = pasantia.IDPasantia }, pasantia);
        }

        // DELETE: api/Pasantias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasantia(int id)
        {
            var pasantia = await _context.Pasantias.FindAsync(id);
            if (pasantia == null)
            {
                return NotFound();
            }

            _context.Pasantias.Remove(pasantia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasantiaExists(int id)
        {
            return _context.Pasantias.Any(e => e.IDPasantia == id);
        }
    }
}
