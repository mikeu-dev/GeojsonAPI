using GeojsonAPI.Models.User;
using GeojsonAPI.Service.Auth;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = GeojsonAPI.Requests.Auth.RegisterRequest;
using LoginRequest = GeojsonAPI.Requests.Auth.LoginRequest;

namespace GeojsonAPI.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] RegisterRequest req)
        {
            try
            {
                var user = _authService.Register(req.Username, req.Email, req.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest req)
        {
            if (_authService.Login(req.Username, req.Password))
                return Ok("Login berhasil");
            return Unauthorized("Username atau password salah");
        }
    }
}
