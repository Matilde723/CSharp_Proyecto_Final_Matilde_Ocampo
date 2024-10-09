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
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBussiness _productoBussiness;

        public ProductoController(ProductoBussiness productoBussiness)
        {
            _productoBussiness = productoBussiness;
        }

        // GET: api/Producto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProducto(int id)
        {
            try
            {
                var producto = await _productoBussiness.ObtenerProducto(id);
                if (producto != null)
                {
                    return Ok(producto);
                }
                return NotFound("Producto no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el producto: {ex.Message}");
            }
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<IActionResult> ListarProductos()
        {
            try
            {
                var productos = await _productoBussiness.ListarProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los productos: {ex.Message}");
            }
        }

        // POST: api/Producto/CrearProducto
        [HttpPost("CrearProducto")]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productoBussiness.CrearProducto(producto);
                    return Ok("Producto creado exitosamente");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al crear el producto: {ex.Message}");
                }
            }
            return BadRequest("Datos del producto no válidos");
        }

        // PUT: api/Producto/ModificarProducto/{id}
        [HttpPut("ModificarProducto/{id}")]
        public async Task<IActionResult> ModificarProducto(int id, [FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingProducto = await _productoBussiness.ObtenerProducto(id);
                    if (existingProducto != null)
                    {
                        producto.Id = id; // Ensure the ID remains the same
                        await _productoBussiness.ModificarProducto(producto);
                        return Ok("Producto modificado exitosamente");
                    }
                    return NotFound("Producto no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al modificar el producto: {ex.Message}");
                }
            }
            return BadRequest("Datos del producto no válidos");
        }

        // DELETE: api/Producto/EliminarProducto/{id}
        [HttpDelete("EliminarProducto/{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            try
            {
                var producto = await _productoBussiness.ObtenerProducto(id);
                if (producto != null)
                {
                    await _productoBussiness.EliminarProducto(id);
                    return Ok("Producto eliminado exitosamente");
                }
                return NotFound("Producto no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el producto: {ex.Message}");
            }
        }
    }
}
