namespace SupplierHub.Constants
{
	// Separate from your IAM's UserStatus to avoid collisions with the existing Users table.
	public enum UserTableStatus
	{
		Active = 1,
		Inactive = 2,
		Suspended = 3,
		Pending = 4
	}
}