namespace SupplierHub.Constants
{
	public enum AuditLog
	{
		Create = 1,
		Update = 2,
		Delete = 3,
		Read = 4,

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
		// IAM
		User = 1,
		Role = 2,

		// Organization & Supplier
		Organization = 10,
		Supplier = 11,
		SupplierContact = 12,
		ComplianceDoc = 13,

		// Category / Items / Catalogs
		Category = 20,
		Item = 21,
		Catalog = 22,
		CatalogItem = 23,
		Contract = 24,

		// RFx / Bids / Awards
		RFxEvent = 30,
		Bid = 31,
		Award = 32,

		// PR / PO / Shipment / ASN / Receiving
		Requisition = 40,
		PRLine = 41,
		PurchaseOrder = 42,
		POLine = 43,
		Shipment = 44,
		ASN = 45,
		GRN = 46,
		GRNItem = 47,

		// Quality
		Inspection = 50,
		NCR = 51,

		// Finance
		Invoice = 60,
		InvoiceLine = 61,
		MatchRef = 62,

		// Notifications & Admin
		Notification = 70,
		ApprovalRule = 71,
		SystemConfig = 72
	}
}
