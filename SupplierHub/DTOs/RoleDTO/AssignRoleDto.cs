using System.ComponentModel.DataAnnotations;

namespace SupplierHub.DTOs.RoleDTO
{
	public class AssignRoleDto
	{
		[Required]
		public long UserID { get; set; }

		[Required]
		public long RoleID { get; set; }
	}
}
