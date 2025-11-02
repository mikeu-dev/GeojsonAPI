using GeojsonAPI.DTO.Auth;
using GeojsonAPI.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GeojsonAPI.Service.Auth;

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

        // ==========================
        // 🔹 REGISTER
        // ==========================
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<UserResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        public ActionResult<ApiResponse<UserResponseDto>> Register([FromBody] RegisterRequest req)
        {
            try
            {
                var user = _authService.Register(req.Username, req.Email, req.Password);

                var responseData = new UserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role
                };

                return Ok(new ApiResponse<UserResponseDto>(
                    true,
                    "Registrasi berhasil",
                    responseData
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(
                    false,
                    ex.Message
                ));
            }
        }

        // ==========================
        // 🔹 LOGIN
        // ==========================
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status401Unauthorized)]
        public ActionResult<ApiResponse<object>> Login([FromBody] LoginRequest req)
        {
            if (_authService.Login(req.Username, req.Password))
            {
                var token = _authService.GenerateJwtToken(req.Username);

                return Ok(new ApiResponse<object>(
                    true,
                    "Login berhasil",
                    new { Token = token }
                ));
            }

            return Unauthorized(new ApiResponse<string>(
                false,
                "Username atau password salah"
            ));
        }
    }
}
