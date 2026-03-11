using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("role")]
	public class Role
	{
		[Key]
		[Column("role_id")]
		public int RoleId { get; set; }  // AUTO_INCREMENT / Identity

		[Required, MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		public string? Description { get; set; }

		// Stored as string via EF conversion (see configuration)
		public RoleStatus Status { get; set; } = RoleStatus.Active;

		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false
	}
}
