// /SupplierHub/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using SupplierHub.DTOs.UserDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService) => _authService = authService;

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
		{
			var result = await _authService.LoginAsync(dto);
			return Ok(result);
		}
	}
}