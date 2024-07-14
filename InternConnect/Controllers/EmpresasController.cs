using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternConnect.Context;
using InternConnect.Models;
using InternConnect.DTO;
using BCrypt.Net;

namespace InternConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly InternConnectContext _context;
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        public EmpresasController(InternConnectContext context)
        {
            _context = context;
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas
                                        .Include(e => e.Rol) // Incluir la carga del rol
                                        .FirstOrDefaultAsync(e => e.IDEmpresa == id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        // PUT: api/Empresas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.IDEmpresa)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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

        // POST: api/Empresas
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.IDEmpresa }, empresa);
        }

        // POST: api/Empresas/upload-logo/5
        [HttpPost("upload-logo/{id}")]
        public async Task<IActionResult> UploadLogo(int id, IFormFile file)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                return BadRequest("Invalid file type. Only JPG and PNG are allowed.");
            }

            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_storagePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Solo guardamos el nombre del archivo
            empresa.LogoEmpresa = fileName;
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { fileName });
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(empresa.LogoEmpresa))
            {
                var fileName = Path.GetFileName(new Uri(empresa.LogoEmpresa).LocalPath);
                var filePath = Path.Combine(_storagePath, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Empresas/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(EmpresaDTO.RegistrarEmpresa registrarEmpresaDto)
        {
            // Validar el modelo recibido según las anotaciones de DataAnnotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si ya existe una empresa con el mismo correo
            if (await _context.Empresas.AnyAsync(e => e.CorreoRRHH == registrarEmpresaDto.Correo))
            {
                return BadRequest("Ya existe una empresa registrada con este correo.");
            }

            // Hash de la contraseña utilizando BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registrarEmpresaDto.ContraseñaHash);

            // Crear una instancia de Empresa con los datos del DTO
            var empresa = new Empresa
            {
                Nombre = registrarEmpresaDto.Nombre,
                CorreoRRHH = registrarEmpresaDto.Correo,
                Direccion = registrarEmpresaDto.Direccion,
                RNC = registrarEmpresaDto.RNC,
                Descripcion = registrarEmpresaDto.Descripcion,
                ContraseñaHash = hashedPassword, // Guardar la contraseña como hash
                FechaIngreso = DateTime.Now,
                Verificacion = false,// Por defecto, la empresa no está verificada
                IDRol = 2 // Asignar el rol de Empresa
            };

            // Agregar la empresa a la base de datos
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.IDEmpresa }, empresa);
        }

        // POST: api/Empresas/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(EmpresaDTO.LoginEmpresa loginEmpresaDto)
        {
            // Validar el modelo recibido según las anotaciones de DataAnnotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar la empresa por correo
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.CorreoRRHH == loginEmpresaDto.Correo);

            if (empresa == null)
            {
                return NotFound("Empresa no encontrada.");
            }

            // Verificar la contraseña
            if (!BCrypt.Net.BCrypt.Verify(loginEmpresaDto.ContraseñaHash, empresa.ContraseñaHash))
            {
                return Unauthorized("Credenciales inválidas.");
            }

            return Ok(empresa);
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.IDEmpresa == id);
        }
    }
}
