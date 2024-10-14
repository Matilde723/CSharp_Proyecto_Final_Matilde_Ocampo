using SistemaGestionData.Context;
using SistemaGestionEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SistemaGestionData.DataAccess
{
    public class AuthDataAccess
    {
        private readonly CoderhouseContext _context;

        public AuthDataAccess(CoderhouseContext context)
        {
            _context = context;
        }

        // Method to retrieve a user based on username and password
        public async Task<Usuario> GetUserByCredentials(string username, string password)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == username && u.Contraseña == password);
        }
    }
}
