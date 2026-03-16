namespace SupplierHub.Constants
{
	// Separate from your other Notification enums to avoid naming collisions.
	public enum NotificationTableCategory
	{
		RFx = 1,
		PR = 2,
		PO = 3,
		ASN = 4,
		GRN = 5,
		Invoice = 6,
		Compliance = 7,
		System = 8
	}

	public enum NotificationTableStatus
	{
		Unread = 1,
		Read = 2,
		Dismissed = 3
	}
}