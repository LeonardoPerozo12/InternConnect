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
    public class AplicacionController : ControllerBase
    {
        private readonly InternConnectContext _context;

        public AplicacionController(InternConnectContext context)
        {
            _context = context;
        }

        // GET: api/Aplicacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacion>>> GetAplicaciones()
        {
            return await _context.Aplicaciones.ToListAsync();
        }

        // GET: api/Aplicacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacion>> GetAplicacion(int id)
        {
            var aplicacion = await _context.Aplicaciones.FindAsync(id);

            if (aplicacion == null)
            {
                return NotFound();
            }

            return aplicacion;
        }

        // PUT: api/Aplicacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacion(int id, Aplicacion aplicacion)
        {
            if (id != aplicacion.IDAplicacion)
            {
                return BadRequest();
            }

            _context.Entry(aplicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacionExists(id))
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

        // POST: api/Aplicacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aplicacion>> PostAplicacion(Aplicacion aplicacion)
        {
            _context.Aplicaciones.Add(aplicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacion", new { id = aplicacion.IDAplicacion }, aplicacion);
        }

        // DELETE: api/Aplicacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacion(int id)
        {
            var aplicacion = await _context.Aplicaciones.FindAsync(id);
            if (aplicacion == null)
            {
                return NotFound();
            }

            _context.Aplicaciones.Remove(aplicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AplicacionExists(int id)
        {
            return _context.Aplicaciones.Any(e => e.IDAplicacion == id);
        }
    }
}
