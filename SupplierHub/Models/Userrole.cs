using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	// maps to table: user_role
	[Table("user_role")]
	public class Userrole
	{
		// Composite PK (UserId, RoleId) -> configured in Fluent API
		public int UserId { get; set; }    // FK → users(UserId)

		public int RoleId { get; set; }    // FK → role(role_id) — if you have a Role table

		// Keep status as string to match your style & the spreadsheet (VARCHAR(30) DEFAULT 'ACTIVE')
		public string Status { get; set; } = "ACTIVE";

		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  
		// default -> false
											 // Optional navigations (uncomment when Role entity exists)
											 // [ForeignKey(nameof(UserId))]
											 // public User User { get; set; }
											 //
											 // [ForeignKey(nameof(RoleId))]
											 // public Role Role { get; set; }
	}
}
