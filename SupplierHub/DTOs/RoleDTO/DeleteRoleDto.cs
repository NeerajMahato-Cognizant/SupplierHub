using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.RoleDTO
{
	public class DeleteRoleDto
	{
		[Required]
		public long UserID { get; set; }

		[Required]
		public long RoleID { get; set; }
	}
}
