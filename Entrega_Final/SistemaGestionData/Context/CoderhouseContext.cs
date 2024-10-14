using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Microsoft.EntityFrameworkCore;
using SistemaGestionEntities;


namespace SistemaGestionData.Context;

public class CoderhouseContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<ProductoVendido> ProductosVendidos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    
    public CoderhouseContext()
        : base() { }

    public CoderhouseContext(DbContextOptions<CoderhouseContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=COMPUMATI\\MSSQLSERVER01;Initial Catalog=PrimeraPreEntrega;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
        );
    }
}
