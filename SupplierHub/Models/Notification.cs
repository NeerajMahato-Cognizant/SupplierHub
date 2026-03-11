using System;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	[Table("Notification")]
	public class Notification
	{
		public long NotificationId { get; set; }

		// MUST MATCH User.UserId (int)
		public int UserId { get; set; }

		public string Message { get; set; }
		public NotificationCategory Category { get; set; }
		public NotificationStatus Status { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }
	}
}

