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
    public class VentaController : ControllerBase
    {
        private readonly VentaBussiness _ventaBussiness;
        private readonly ProductoVendidoBussiness _productoVendidoBussiness;
        private readonly ProductoBussiness _productoBussiness;

        public VentaController(VentaBussiness ventaBussiness, ProductoVendidoBussiness productoVendidoBussiness, ProductoBussiness productoBussiness)
        {
            _ventaBussiness = ventaBussiness;
            _productoVendidoBussiness = productoVendidoBussiness;
            _productoBussiness = productoBussiness;
        }

        // POST: api/Venta/CargarVenta
        [HttpPost("CargarVenta")]
        public async Task<IActionResult> CargarVenta([FromBody] CargarVentaRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Step 1: Create a new Venta with the IdUsuario using the VentaBussiness service
                    var nuevaVenta = new Venta
                    {
                        IdUsuario = request.IdUsuario,
                        Comentarios = request.Comentarios // Assuming comments are optional
                    };

                    await _ventaBussiness.CrearVenta(nuevaVenta);

                    // Step 2: For each product in the list, add to ProductosVendidos and update stock
                    foreach (var productoVendido in request.Productos)
                    {
                        // Step 2a: Create and save ProductoVendido
                        var nuevoProductoVendido = new ProductoVendido
                        {
                            IdProducto = productoVendido.IdProducto,
                            Cantidad = productoVendido.Cantidad,
                            IdVenta = nuevaVenta.Id
                        };

                        await _productoVendidoBussiness.CrearProductoVendido(nuevoProductoVendido);

                        // Step 2b: Update stock in the Productos table using ProductoBussiness
                        var producto = await _productoBussiness.ObtenerProducto(productoVendido.IdProducto);
                        if (producto != null)
                        {
                            producto.Stock -= productoVendido.Cantidad;
                            if (producto.Stock < 0)
                            {
                                return BadRequest($"Stock insuficiente para el producto con ID {producto.Id}");
                            }
                            await _productoBussiness.ModificarProducto(producto);
                        }
                        else
                        {
                            return NotFound($"Producto con ID {productoVendido.IdProducto} no encontrado");
                        }
                    }

                    return Ok("Venta cargada exitosamente");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al cargar la venta: {ex.Message}");
                }
            }

            return BadRequest("Datos de la venta no válidos");
        }

        // GET: api/Venta/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerVenta(int id)
        {
            try
            {
                var venta = await _ventaBussiness.ObtenerVenta(id);
                if (venta != null)
                {
                    return Ok(venta);
                }
                return NotFound("Venta no encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la venta: {ex.Message}");
            }
        }

        // GET: api/Venta
        [HttpGet]
        public async Task<IActionResult> ListarVentas()
        {
            try
            {
                var ventas = await _ventaBussiness.ListarVentas();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar las ventas: {ex.Message}");
            }
        }

        // PUT: api/Venta/ModificarVenta/{id}
        [HttpPut("ModificarVenta/{id}")]
        public async Task<IActionResult> ModificarVenta(int id, [FromBody] Venta venta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingVenta = await _ventaBussiness.ObtenerVenta(id);
                    if (existingVenta != null)
                    {
                        venta.Id = id; // Ensure the ID remains the same
                        await _ventaBussiness.ModificarVenta(venta);
                        return Ok("Venta modificada exitosamente");
                    }
                    return NotFound("Venta no encontrada");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error al modificar la venta: {ex.Message}");
                }
            }
            return BadRequest("Datos de la venta no válidos");
        }

        // DELETE: api/Venta/EliminarVenta/{id}
        [HttpDelete("EliminarVenta/{id}")]
        public async Task<IActionResult> EliminarVenta(int id)
        {
            try
            {
                var venta = await _ventaBussiness.ObtenerVenta(id);
                if (venta != null)
                {
                    await _ventaBussiness.EliminarVenta(id);
                    return Ok("Venta eliminada exitosamente");
                }
                return NotFound("Venta no encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la venta: {ex.Message}");
            }
        }
    }

    // Request model for CargarVenta
    public class CargarVentaRequest
    {
        public int IdUsuario { get; set; }
        public string Comentarios { get; set; }
        public List<ProductoVendidoRequest> Productos { get; set; }
    }

    // Model for each ProductoVendido in the request
    public class ProductoVendidoRequest
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
