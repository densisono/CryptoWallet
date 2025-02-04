using Microsoft.AspNetCore.Mvc;

namespace PSS.DHPM.CryptoWallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
		[HttpPost("login")]
		public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
		{
			var result = await _authService.LoginAsync(request.Email, request.Password);
			if (!result.Success)
            {
                return BadRequest(result.Message);
            }
			return Ok(result);
		}
		[HttpPost("register")]
		public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
		{
			var result = await _authService.RegisterAsync(request.Email, request.Password, request.Username);
			if (!result.Success)
            {
                return BadRequest(result.Message);
            }
			return Ok(result);
		}
	}
}