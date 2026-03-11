using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	[Table("role_permission")]
	public class Rolepermission
	{
		// Composite Key (configured in Fluent API)
		public int RoleId { get; set; }          // FK → role(role_id)
		public int PermissionId { get; set; }    // FK → permission(permission_id)

		// Status as VARCHAR(30) with default 'ACTIVE'
		public string Status { get; set; } = "ACTIVE";

		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }

		// OPTIONAL Navigation properties (enable when Role & Permission models exist)

		// public Role Role { get; set; }
		// public Permission Permission { get; set; }
	}
}
