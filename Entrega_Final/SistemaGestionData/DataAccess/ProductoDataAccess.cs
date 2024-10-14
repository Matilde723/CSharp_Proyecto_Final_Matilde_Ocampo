
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionData;
using SistemaGestionData.DataAccess;
using SistemaGestionData.Context;
using SistemaGestionEntities;


namespace SistemaGestionData.DataAccess; 


public class ProductoDataAccess
{
    private readonly CoderhouseContext _context;

    public ProductoDataAccess(CoderhouseContext context)
    {
        _context = context;
    }

    // ObtenerProducto - Using LINQ instead of manual SQL
    public List<Producto> ObtenerProducto(int id)
    {
        try
        {
            var lista = _context.Productos
                               .Where(p => p.Id == id)
                               .ToList();
            return lista;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while fetching product", ex);
        }
    }

    // ListarProductos - Using LINQ to get all products
    public List<Producto> ListarProductos()
    {
        try
        {
            return _context.Productos.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while listing products", ex);
        }
    }

    // CrearProducto - Adding a new product using EF
    public void CrearProducto(Producto producto)
    {
        try
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating product", ex);
        }
    }

    // ModificarProducto - Updating a product using EF
    public void ModificarProducto(Producto producto)
    {
        try
        {
            var existingProducto = _context.Productos.Find(producto.Id);
            if (existingProducto != null)
            {
                existingProducto.Descripcion = producto.Descripcion;
                existingProducto.Costo = producto.Costo;
                existingProducto.PrecioVenta = producto.PrecioVenta;
                existingProducto.Stock = producto.Stock;
                existingProducto.IdUsuario = producto.IdUsuario;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating product", ex);
        }
    }

    // EliminarProducto - Deleting a product using EF
    public void EliminarProducto(int productoId)
    {
        try
        {
            var producto = _context.Productos.Find(productoId);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting product", ex);
        }
    }
}