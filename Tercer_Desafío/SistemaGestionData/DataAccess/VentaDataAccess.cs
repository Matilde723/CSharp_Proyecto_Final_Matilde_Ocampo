using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;

using SistemaGestionData;
using SistemaGestionData.DataAccess;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess
{
    public class VentaDataAccess
    {
        private readonly CoderhouseContext _context;

        public VentaDataAccess(CoderhouseContext context)
        {
            _context = context;
        }

        // ObtenerVenta - Fetch a Venta by ID using LINQ
        public Venta ObtenerVenta(int id)
        {
            try
            {
                var venta = _context.Ventas.FirstOrDefault(v => v.Id == id);
                if (venta == null)
                {
                    throw new Exception("Venta not found");
                }
                return venta;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching Venta", ex);
            }
        }

        // ListarVentas - Fetch all Ventas using LINQ
        public List<Venta> ListarVentas()
        {
            try
            {
                return _context.Ventas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while listing Ventas", ex);
            }
        }

        // CrearVenta - Add a new Venta using Entity Framework
        public void CrearVenta(Venta venta)
        {
            try
            {
                _context.Ventas.Add(venta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating Venta", ex);
            }
        }

        // ModificarVenta - Update an existing Venta using Entity Framework
        public void ModificarVenta(Venta venta)
        {
            try
            {
                var existingVenta = _context.Ventas.FirstOrDefault(v => v.Id == venta.Id);
                if (existingVenta != null)
                {
                    existingVenta.Comentarios = venta.Comentarios;
                    existingVenta.IdUsuario = venta.IdUsuario;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Venta not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating Venta", ex);
            }
        }

        // EliminarVenta - Delete a Venta using Entity Framework
        public void EliminarVenta(int id)
        {
            try
            {
                var venta = _context.Ventas.FirstOrDefault(v => v.Id == id);
                if (venta != null)
                {
                    _context.Ventas.Remove(venta);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Venta not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting Venta", ex);
            }
        }
    }
}
