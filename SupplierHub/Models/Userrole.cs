using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class UserRole
	{
		[Required]
		public long UserID { get; set; }

		[Required]
		public long RoleID { get; set; }

		[Required, MaxLength(30)]
		public required string Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		[Required]
		public DateTime UpdatedOn { get; set; }

		[Required]
		public bool IsDeleted { get; set; }


		// Navigation to User
		[ForeignKey(nameof(UserID))]
		public User User { get; set; } = null!;

		// Navigation to Role
		[ForeignKey(nameof(RoleID))]
		public Role Role { get; set; } = null!;
	}
}