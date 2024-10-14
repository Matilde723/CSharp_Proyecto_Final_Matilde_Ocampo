using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System;
using System.Threading.Tasks;

namespace SistemaGestionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly ProductoVendidoBussiness _productoVendidoBussiness;

        public ProductoVendidoController(ProductoVendidoBussiness productoVendidoBussiness)
        {
            _productoVendidoBussiness = productoVendidoBussiness;
        }

        // GET: api/ProductoVendido/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProductoVendido(int id)
        {
            try
            {
                var productoVendido = await _productoVendidoBussiness.ObtenerProductoVendido(id);
                if (productoVendido != null)
                {
                    return Ok(productoVendido);
                }
                return NotFound("ProductoVendido no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el ProductoVendido: {ex.Message}");
            }
        }

        // GET: api/ProductoVendido
        [HttpGet]
        public async Task<IActionResult> ListarProductosVendidos()
        {
            try
            {
                var productosVendidos = await _productoVendidoBussiness.ListarProductosVendidos();
                return Ok(productosVendidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los productos vendidos: {ex.Message}");
            }
        }

        // POST: api/ProductoVendido/CrearProductoVendido
        [HttpPost("CrearProductoVendido")]
        public async Task<IActionResult> CrearProductoVendido([FromBody] ProductoVendido productoVendido)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productoVendidoBussiness.CrearProductoVendido(productoVendido);
                    return Ok("ProductoVendido creado exitosamente");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al crear el ProductoVendido: {ex.Message}");
                }
            }
            return BadRequest("Datos del ProductoVendido no válidos");
        }

        // PUT: api/ProductoVendido/ModificarProductoVendido/{id}
        [HttpPut("ModificarProductoVendido/{id}")]
        public async Task<IActionResult> ModificarProductoVendido(int id, [FromBody] ProductoVendido productoVendido)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingProductoVendido = await _productoVendidoBussiness.ObtenerProductoVendido(id);
                    if (existingProductoVendido != null)
                    {
                        productoVendido.Id = id; // Ensure the ID remains the same
                        await _productoVendidoBussiness.ModificarProductoVendido(productoVendido);
                        return Ok("ProductoVendido modificado exitosamente");
                    }
                    return NotFound("ProductoVendido no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al modificar el ProductoVendido: {ex.Message}");
                }
            }
            return BadRequest("Datos del ProductoVendido no válidos");
        }

        // DELETE: api/ProductoVendido/EliminarProductoVendido/{id}
        [HttpDelete("EliminarProductoVendido/{id}")]
        public async Task<IActionResult> EliminarProductoVendido(int id)
        {
            try
            {
                var productoVendido = await _productoVendidoBussiness.ObtenerProductoVendido(id);
                if (productoVendido != null)
                {
                    await _productoVendidoBussiness.EliminarProductoVendido(id);
                    return Ok("ProductoVendido eliminado exitosamente");
                }
                return NotFound("ProductoVendido no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el ProductoVendido: {ex.Message}");
            }
        }
    }
}
