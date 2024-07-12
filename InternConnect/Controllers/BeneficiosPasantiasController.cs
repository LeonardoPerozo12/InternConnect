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
    public class BeneficiosPasantiasController : ControllerBase
    {
        private readonly InternConnectContext _context;

        public BeneficiosPasantiasController(InternConnectContext context)
        {
            _context = context;
        }

        // GET: api/BeneficiosPasantias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficiosPasantia>>> GetBeneficiosPasantias()
        {
            return await _context.BeneficiosPasantias.ToListAsync();
        }

        // GET: api/BeneficiosPasantias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficiosPasantia>> GetBeneficiosPasantia(int id)
        {
            var beneficiosPasantia = await _context.BeneficiosPasantias.FindAsync(id);

            if (beneficiosPasantia == null)
            {
                return NotFound();
            }

            return beneficiosPasantia;
        }

        // PUT: api/BeneficiosPasantias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiosPasantia(int id, BeneficiosPasantia beneficiosPasantia)
        {
            if (id != beneficiosPasantia.IDBeneficios)
            {
                return BadRequest();
            }

            _context.Entry(beneficiosPasantia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiosPasantiaExists(id))
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

        // POST: api/BeneficiosPasantias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BeneficiosPasantia>> PostBeneficiosPasantia(BeneficiosPasantia beneficiosPasantia)
        {
            _context.BeneficiosPasantias.Add(beneficiosPasantia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BeneficiosPasantiaExists(beneficiosPasantia.IDBeneficios))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBeneficiosPasantia", new { id = beneficiosPasantia.IDBeneficios }, beneficiosPasantia);
        }

        // DELETE: api/BeneficiosPasantias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiosPasantia(int id)
        {
            var beneficiosPasantia = await _context.BeneficiosPasantias.FindAsync(id);
            if (beneficiosPasantia == null)
            {
                return NotFound();
            }

            _context.BeneficiosPasantias.Remove(beneficiosPasantia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiosPasantiaExists(int id)
        {
            return _context.BeneficiosPasantias.Any(e => e.IDBeneficios == id);
        }
    }
}
