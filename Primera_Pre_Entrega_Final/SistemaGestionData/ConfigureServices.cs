using SistemaGestionData.Context;
using SistemaGestionData.DataAccess;
using SistemaGestionData;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaGestionData;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureDataLayer(this IServiceCollection services)
    {
        services.AddDbContext<CoderhouseContext>();
        services.AddScoped<ProductoDataAccess>();
        services.AddScoped<ProductoVendidoDataAccess>();
        services.AddScoped<UsuarioDataAccess>();
        services.AddScoped<VentaDataAccess>();
        return services;


    }
}
