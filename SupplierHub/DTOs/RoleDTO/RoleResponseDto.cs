using System;

namespace SupplierHub.DTOs.RoleDTO
{
	public class RoleResponseDto
	{
		public long UserRoleID { get; set; }
		public long UserID { get; set; }
		public long RoleID { get; set; }
		public string RoleName { get; set; } = string.Empty;
		public bool IsDeleted { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }
	}
}
