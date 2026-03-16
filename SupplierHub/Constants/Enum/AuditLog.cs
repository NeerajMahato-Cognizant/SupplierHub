namespace SupplierHub.Constants
{
	// For audit_log.status (stored as string)
	public enum AuditTableStatus
	{
		Active = 1,
		Inactive = 2,
		Archived = 3
	}

	// Optional: use these enums in services and convert to string when saving.
	// Example: log.Action = AuditAction.Create.ToString();
	public enum AuditAction
	{
		Create = 1,
		Read = 2,
		Update = 3,
		Delete = 4,
		Login = 10,
		Logout = 11,
		Submit = 20,
		Approve = 21,
		Reject = 22,
		Cancel = 23,
		Close = 24
	}

	public enum AuditResource
	{
		User = 1,
		Role = 2,
		Permission = 3,
		Organization = 10,
		Supplier = 11,
		Category = 12,
		Item = 13,
		Catalog = 14,
		Contract = 15,
		RFxEvent = 30,
		Bid = 31,
		Award = 32,
		Requisition = 40,
		PurchaseOrder = 41,
		Shipment = 42,
		ASN = 43,
		GRN = 44,
		Invoice = 50,
		Notification = 60,
		SystemConfig = 61,
		ApprovalRule = 62
	}
}

