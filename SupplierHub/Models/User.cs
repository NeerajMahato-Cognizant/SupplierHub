using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	// Maps to the spreadsheet's table: user
	[Table("user")]
	public class User
	{
		[Key]
		[Column("user_id")]
		public int AppUserId { get; set; } // AUTO_INCREMENT / Identity

		[Column("org_id")]
		public int OrgId { get; set; }     // FK → organization(org_id) (add FK later if Org model exists)

		[Required, MaxLength(150)]
		[Column("name")]
		public string Name { get; set; }

		[Required, MaxLength(150)]
		[Column("email")]
		public string Email { get; set; }

		[MaxLength(30)]
		[Column("phone")]
		public string? Phone { get; set; }

		[MaxLength(255)]
		[Column("password_hash")]
		public string? PasswordHash { get; set; }

		// Stored as string via EF conversion; defaults to "Active" in config to match sheet's 'ACTIVE'
		[Column("status")]
		public UserTableStatus Status { get; set; } = UserTableStatus.Active;

		[Column("createdon")]
		public DateTime CreatedOn { get; set; }

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}