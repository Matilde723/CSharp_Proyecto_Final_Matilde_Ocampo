using SistemaGestionData.DataAccess;
using SistemaGestionData;
using SistemaGestionEntities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace SistemaGestionBussiness
{
    public class ProductoBussiness
    {
        private readonly ProductoDataAccess _productoDataAccess;

        public ProductoBussiness(ProductoDataAccess productoDataAccess)
        {
            _productoDataAccess = productoDataAccess;
        }

        // Fetch one product by ID
        public async Task<Producto> ObtenerProducto(int id)
        {
            try
            {
                var productos = await Task.Run(() => _productoDataAccess.ObtenerProducto(id));
                return productos.Count > 0 ? productos[0] : null;  // Return first product or null if not found
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching product: {ex.Message}");
            }
        }

        // Fetch all products
        public async Task<List<Producto>> ListarProductos()
        {
            try
            {
                return await Task.Run(() => _productoDataAccess.ListarProductos());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error listing products: {ex.Message}");
            }
        }

        // Create a new product
        public async Task CrearProducto(Producto producto)
        {
            try
            {
                await Task.Run(() => _productoDataAccess.CrearProducto(producto));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating product: {ex.Message}");
            }
        }

        // Update an existing product
        public async Task ModificarProducto(Producto producto)
        {
            try
            {
                await Task.Run(() => _productoDataAccess.ModificarProducto(producto));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}");
            }
        }

        // Delete a product by ID
        public async Task EliminarProducto(int id)
        {
            try
            {
                await Task.Run(() => _productoDataAccess.EliminarProducto(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}");
            }
        }
    }
}
