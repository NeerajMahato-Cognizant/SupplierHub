using System.ComponentModel.DataAnnotations;
using SupplierHub.Constants;
using SupplierHub.Constants.Enum;

namespace SupplierHub.DTOs.Notification
{
	public class CreateNotificationRequestDto
	{
		[Required]
		public int UserID { get; set; }

		public int? ContractID { get; set; }

		[Required]
		public string Message { get; set; } = default!;

		[Required]
		public NotificationTableCategory Category { get; set; }

		// Optional: if omitted, service will default to Unread
		public NotificationTableStatus? Status { get; set; }
	}

}
