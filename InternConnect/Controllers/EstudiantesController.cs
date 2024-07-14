    using System;
    using BCrypt.Net;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using InternConnect.Context;
    using InternConnect.Models;
    using InternConnect.DTO; // Asegúrate de incluir el espacio de nombres donde está definido EstudianteDTO
    using Microsoft.AspNetCore.Authorization; // Para la autorización si es necesario

    namespace InternConnect.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EstudiantesController : ControllerBase
        {
            private readonly InternConnectContext _context;

            public EstudiantesController(InternConnectContext context)
            {
                _context = context;
            }

            // GET: api/Estudiantes
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
            {
                return await _context.Estudiantes.ToListAsync();
            }

            // GET: api/Estudiantes/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
            {
                var estudiante = await _context.Estudiantes.FindAsync(id);

                if (estudiante == null)
                {
                    return NotFound();
                }

                return estudiante;
            }

            // POST: api/Estudiantes/Register
            [HttpPost("Register")]
            public async Task<IActionResult> Register(EstudianteDTO.RegistrarEstudiante registrarEstudianteDto)
            {
                // Validar el modelo recibido según las anotaciones de DataAnnotations
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verificar si ya existe un estudiante con el mismo correo
                if (await _context.Estudiantes.AnyAsync(e => e.Correo == registrarEstudianteDto.Correo))
                {
                    return BadRequest("Ya existe un estudiante registrado con este correo.");
                }

                // Hash de la contraseña utilizando BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registrarEstudianteDto.ContraseñaHash);

                // Crear una instancia de Estudiante con los datos del DTO
                var estudiante = new Estudiante
                {
                    Nombre = registrarEstudianteDto.Nombre,
                    Correo = registrarEstudianteDto.Correo,
                    IDUniversidad = registrarEstudianteDto.IDUniversidad,
                    IDCarrera = registrarEstudianteDto.IDCarrera,
                    Direccion = registrarEstudianteDto.Direccion,
                    Telefono = registrarEstudianteDto.Telefono,
                    TipoDocumento = registrarEstudianteDto.TipoDocumento,
                    Documento = registrarEstudianteDto.Documento,
                    ContraseñaHash = hashedPassword, // Guardar la contraseña como hash
                    IDRol = 1 // Asignar el rol de Estudiante
                };

                // Agregar el estudiante a la base de datos
                _context.Estudiantes.Add(estudiante);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEstudiante", new { id = estudiante.IDEstudiante }, estudiante);
            }

            // POST: api/Estudiantes/Login
            [HttpPost("Login")]
            public async Task<IActionResult> Login(EstudianteDTO.LoginEstudiante loginEstudianteDto)
            {
                // Validar el modelo recibido según las anotaciones de DataAnnotations
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Buscar el estudiante por correo
                var estudiante = await _context.Estudiantes.FirstOrDefaultAsync(e => e.Correo == loginEstudianteDto.Correo);

                if (estudiante == null)
                {
                    return NotFound("Estudiante no encontrado.");
                }

                // Verificar la contraseña
                if (!BCrypt.Net.BCrypt.Verify(loginEstudianteDto.Contraseña, estudiante.ContraseñaHash))
                {
                    return Unauthorized("Credenciales inválidas.");
                }

                return Ok(estudiante);
            }

            // PUT: api/Estudiantes/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
            {
                if (id != estudiante.IDEstudiante)
                {
                    return BadRequest();
                }

                _context.Entry(estudiante).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(id))
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

            // DELETE: api/Estudiantes/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEstudiante(int id)
            {
                var estudiante = await _context.Estudiantes.FindAsync(id);
                if (estudiante == null)
                {
                    return NotFound();
                }

                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool EstudianteExists(int id)
            {
                return _context.Estudiantes.Any(e => e.IDEstudiante == id);
            }
        }
    }
