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
    public class ProductoVendidoDataAccess
    {
        private readonly CoderhouseContext _context;

        public ProductoVendidoDataAccess(CoderhouseContext context)
        {
            _context = context;
        }

        // ObtenerProductoVendido - Using LINQ instead of manual SQL
        public ProductoVendido ObtenerProductoVendido(int id)
        {
            try
            {
                var productoVendido = _context.ProductosVendidos.FirstOrDefault(pv => pv.Id == id);
                if (productoVendido == null)
                {
                    throw new Exception("ProductoVendido not found");
                }
                return productoVendido;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching ProductoVendido", ex);
            }
        }

        // ListarProductosVendidos - Using LINQ to get all products sold
        public List<ProductoVendido> ListarProductosVendidos()
        {
            try
            {
                return _context.ProductosVendidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while listing ProductosVendidos", ex);
            }
        }

        // CrearProductoVendido - Adding a new ProductoVendido using EF
        public void CrearProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                _context.ProductosVendidos.Add(productoVendido);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating ProductoVendido", ex);
            }
        }

        // ModificarProductoVendido - Updating an existing ProductoVendido using EF
        public void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                var existingProductoVendido = _context.ProductosVendidos.FirstOrDefault(pv => pv.Id == productoVendido.Id);
                if (existingProductoVendido != null)
                {
                    existingProductoVendido.IdProducto = productoVendido.IdProducto;
                    existingProductoVendido.Stock = productoVendido.Stock;
                    existingProductoVendido.IdVenta = productoVendido.IdVenta;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("ProductoVendido not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating ProductoVendido", ex);
            }
        }

        // EliminarProductoVendido - Deleting a ProductoVendido using EF
        public void EliminarProductoVendido(int id)
        {
            try
            {
                var productoVendido = _context.ProductosVendidos.FirstOrDefault(pv => pv.Id == id);
                if (productoVendido != null)
                {
                    _context.ProductosVendidos.Remove(productoVendido);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("ProductoVendido not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting ProductoVendido", ex);
            }
        }
    }
}
