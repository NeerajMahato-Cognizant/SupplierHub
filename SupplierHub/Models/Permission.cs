using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("permission")]
	public class Permission
	{
		[Key]
		[Column("permission_id")]
		public int PermissionId { get; set; }   // AUTO_INCREMENT (use int to match EF)

		[Required, MaxLength(120)]
		public string Code { get; set; }

		[Required, MaxLength(150)]
		public string Name { get; set; }

		[MaxLength(255)]
		public string? Description { get; set; }

		public PermissionStatus Status { get; set; } = PermissionStatus.Active;

		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false
	}
}
