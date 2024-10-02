using SistemaGestionData.DataAccess;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class VentaBussiness
    {
        private readonly VentaDataAccess _ventaDataAccess;

        public VentaBussiness(VentaDataAccess ventaDataAccess)
        {
            _ventaDataAccess = ventaDataAccess;
        }

        // Get a Venta by ID
        public async Task<Venta> ObtenerVenta(int id)
        {
            try
            {
                var venta = await Task.Run(() => _ventaDataAccess.ObtenerVenta(id));
                if (venta == null)
                {
                    throw new Exception("Venta not found");
                }
                return venta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Venta with ID {id}: {ex.Message}");
            }
        }

        // List all Ventas
        public async Task<List<Venta>> ListarVentas()
        {
            try
            {
                return await Task.Run(() => _ventaDataAccess.ListarVentas());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error listing Ventas: {ex.Message}");
            }
        }

        // Create a new Venta
        public async Task CrearVenta(Venta venta)
        {
            try
            {
                await Task.Run(() => _ventaDataAccess.CrearVenta(venta));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating Venta: {ex.Message}");
            }
        }

        // Update an existing Venta
        public async Task ModificarVenta(Venta venta)
        {
            try
            {
                await Task.Run(() => _ventaDataAccess.ModificarVenta(venta));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Venta: {ex.Message}");
            }
        }

        // Delete a Venta by ID
        public async Task EliminarVenta(int id)
        {
            try
            {
                await Task.Run(() => _ventaDataAccess.EliminarVenta(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Venta with ID {id}: {ex.Message}");
            }
        }
    }
}
