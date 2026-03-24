using SupplierHub.Constants;
using SupplierHub.Constants.Enum;

namespace SupplierHub.DTOs.Notification
{
	public class NotificationResponseDto
	{
		public int NotificationID { get; set; }

		public int UserID { get; set; }
		public string? UserName { get; set; }

		public int? ContractID { get; set; }

		public string Message { get; set; } = default!;
		public NotificationTableCategory Category { get; set; }
		public NotificationTableStatus Status { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}

}
