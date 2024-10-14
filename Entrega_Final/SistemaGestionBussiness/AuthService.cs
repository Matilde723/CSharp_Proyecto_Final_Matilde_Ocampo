using SistemaGestionData.DataAccess;
using SistemaGestionEntities;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class AuthService
    {
        private readonly AuthDataAccess _authDataAccess;

        public AuthService(AuthDataAccess authDataAccess)
        {
            _authDataAccess = authDataAccess;
        }

        // Method to authenticate a user based on username and password
        public async Task<AuthResponse> Authenticate(AuthRequest authRequest)
        {
            var user = await _authDataAccess.GetUserByCredentials(authRequest.Username, authRequest.Password);

            if (user != null)
            {
                // Generate a token (optional) or return authenticated user info
                return new AuthResponse
                {
                    Username = user.NombreUsuario,
                    Token = "dummy-jwt-token" // Placeholder for JWT generation logic
                };
            }

            return null;
        }
    }
}
