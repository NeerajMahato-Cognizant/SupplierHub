using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	// Maps to the spreadsheet table: notification
	[Table("notification")]
	public class Notification
	{
		[Key]
		[Column("notification_id")]
		public int NotificationId { get; set; }  // AUTO_INCREMENT / Identity

		[Column("user_id")]
		public int UserId { get; set; }          // FK → app_user(user_id)

		[Required, MaxLength(500)]
		[Column("message")]
		public string Message { get; set; }

		// Stored as string via EF conversion (see configuration)
		[Column("category")]
		public NotificationTableCategory Category { get; set; }

		[Column("ref_entity_id")]
		public int? RefEntityId { get; set; }

		[Column("status")]
		public NotificationTableStatus Status { get; set; } = NotificationTableStatus.Unread;

		// Per sheet: both created_date and createdon exist
		[Column("created_date")]
		public DateTime CreatedDate { get; set; }

		[Column("createdon")]
		public DateTime CreatedOn { get; set; }

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false

											 // Optional navigation (enable when AppUser is in your DbContext)
											 // [ForeignKey(nameof(UserId))]
											 // public AppUser User { get; set; }
	}
}


