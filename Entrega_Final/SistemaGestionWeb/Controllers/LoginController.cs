using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Threading.Tasks;

namespace SistemaGestionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
        {
            if (ModelState.IsValid)
            {
                var authResponse = await _authService.Authenticate(authRequest);

                if (authResponse != null)
                {
                    return Ok(authResponse); // Return token or auth info
                }
                return Unauthorized("Invalid credentials");
            }
            return BadRequest("Invalid request");
        }
    }
}
