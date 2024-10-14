using SistemaGestionData.DataAccess;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoVendidoBussiness
    {
        private readonly ProductoVendidoDataAccess _productoVendidoDataAccess;

        public ProductoVendidoBussiness(ProductoVendidoDataAccess productoVendidoDataAccess)
        {
            _productoVendidoDataAccess = productoVendidoDataAccess;
        }

        // Get a ProductoVendido by ID
        public async Task<ProductoVendido> ObtenerProductoVendido(int id)
        {
            try
            {
                var productoVendido = await Task.Run(() => _productoVendidoDataAccess.ObtenerProductoVendido(id));
                if (productoVendido == null)
                {
                    throw new Exception("ProductoVendido not found");
                }
                return productoVendido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching ProductoVendido with ID {id}: {ex.Message}");
            }
        }

        // List all ProductosVendidos
        public async Task<List<ProductoVendido>> ListarProductosVendidos()
        {
            try
            {
                return await Task.Run(() => _productoVendidoDataAccess.ListarProductosVendidos());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error listing ProductosVendidos: {ex.Message}");
            }
        }

        // Create a new ProductoVendido
        public async Task CrearProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                await Task.Run(() => _productoVendidoDataAccess.CrearProductoVendido(productoVendido));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating ProductoVendido: {ex.Message}");
            }
        }

        // Update an existing ProductoVendido
        public async Task ModificarProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                await Task.Run(() => _productoVendidoDataAccess.ModificarProductoVendido(productoVendido));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating ProductoVendido: {ex.Message}");
            }
        }

        // Delete a ProductoVendido by ID
        public async Task EliminarProductoVendido(int id)
        {
            try
            {
                await Task.Run(() => _productoVendidoDataAccess.EliminarProductoVendido(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting ProductoVendido with ID {id}: {ex.Message}");
            }
        }
    }
}
