using System;
using System.Collections.Generic;

namespace SupplierHub.DTOs.UserDTO
{
    public class LoginResponseDto : CreateUserDto
    {
        public string Token { get; set; } = default!;

        // UTC expiry timestamp for the token
        public DateTime ExpiresAtUtc { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = default!;

        public List<string> Roles { get; set; } = new List<string>();
    }
}
