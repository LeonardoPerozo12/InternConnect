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
    public class BeneficiosController : ControllerBase
    {
        private readonly InternConnectContext _context;

        public BeneficiosController(InternConnectContext context)
        {
            _context = context;
        }

        // GET: api/Beneficios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficios>>> GetBeneficios()
        {
            return await _context.Beneficios.ToListAsync();
        }

        // GET: api/Beneficios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficios>> GetBeneficios(int id)
        {
            var beneficios = await _context.Beneficios.FindAsync(id);

            if (beneficios == null)
            {
                return NotFound();
            }

            return beneficios;
        }

        // PUT: api/Beneficios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficios(int id, Beneficios beneficios)
        {
            if (id != beneficios.IDBeneficios)
            {
                return BadRequest();
            }

            _context.Entry(beneficios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiosExists(id))
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

        // POST: api/Beneficios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beneficios>> PostBeneficios(Beneficios beneficios)
        {
            _context.Beneficios.Add(beneficios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficios", new { id = beneficios.IDBeneficios }, beneficios);
        }

        // DELETE: api/Beneficios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficios(int id)
        {
            var beneficios = await _context.Beneficios.FindAsync(id);
            if (beneficios == null)
            {
                return NotFound();
            }

            _context.Beneficios.Remove(beneficios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiosExists(int id)
        {
            return _context.Beneficios.Any(e => e.IDBeneficios == id);
        }
    }
}
