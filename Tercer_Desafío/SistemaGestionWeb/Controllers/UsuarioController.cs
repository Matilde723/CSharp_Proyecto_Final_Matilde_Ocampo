using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBussiness _usuarioBussiness;

        public UsuarioController(UsuarioBussiness usuarioBussiness)
        {
            _usuarioBussiness = usuarioBussiness;
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioBussiness.ObtenerUsuario(id);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return NotFound("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario: {ex.Message}");
            }
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioBussiness.ListarUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los usuarios: {ex.Message}");
            }
        }

        // POST: api/Usuario/CrearUsuario
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioBussiness.CrearUsuario(usuario);
                    return Ok("Usuario creado exitosamente");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al crear el usuario: {ex.Message}");
                }
            }
            return BadRequest("Datos del usuario no válidos");
        }

        // PUT: api/Usuario/ModificarUsuario/{id}
        [HttpPut("ModificarUsuario/{id}")]
        public async Task<IActionResult> ModificarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUsuario = await _usuarioBussiness.ObtenerUsuario(id);
                    if (existingUsuario != null)
                    {
                        usuario.Id = id; // Ensure the ID remains the same
                        await _usuarioBussiness.ModificarUsuario(usuario);
                        return Ok("Usuario modificado exitosamente");
                    }
                    return NotFound("Usuario no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al modificar el usuario: {ex.Message}");
                }
            }
            return BadRequest("Datos del usuario no válidos");
        }

        // DELETE: api/Usuario/EliminarUsuario/{id}
        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioBussiness.ObtenerUsuario(id);
                if (usuario != null)
                {
                    await _usuarioBussiness.EliminarUsuario(id);
                    return Ok("Usuario eliminado exitosamente");
                }
                return NotFound("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el usuario: {ex.Message}");
            }
        }
    }
}
