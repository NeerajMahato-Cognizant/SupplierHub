using SupplierHub.DTOs.UserDTO;

namespace SupplierHub.Services.Interface
{
	public interface IAuthService
	{
		Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
	}
}
