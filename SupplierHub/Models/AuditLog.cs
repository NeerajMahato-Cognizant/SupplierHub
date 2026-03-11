using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants;

namespace SupplierHub.Models
{
	// Maps to the spreadsheet table: audit_log
	[Table("audit_log")]
	public class AuditLog
	{
		[Key]
		[Column("audit_id")]
		public int AuditId { get; set; }  // AUTO_INCREMENT / Identity

		[Column("user_id")]
		public int? UserId { get; set; }  // FK → app_user(user_id); nullable for system actions

		// As per sheet: VARCHAR(100/200) NOT NULL
		[Required, MaxLength(100)]
		[Column("action")]
		public string Action { get; set; } = string.Empty;

		[Required, MaxLength(200)]
		[Column("resource")]
		public string Resource { get; set; } = string.Empty;

		// JSON payload (store as text/json)
		[Column("metadata")]
		public string? MetadataJson { get; set; }

		// Timestamp defaults to CURRENT_TIMESTAMP in DB
		[Column("timestamp")]
		public DateTime Timestamp { get; set; }

		// status VARCHAR(30) NOT NULL DEFAULT 'ACTIVE' (we use enum + string conversion)
		[Column("status")]
		public AuditTableStatus Status { get; set; } = AuditTableStatus.Active;

		[Column("createdon")]
		public DateTime CreatedOn { get; set; }

		[Column("updatedon")]
		public DateTime UpdatedOn { get; set; }

		public bool IsDeleted { get; set; }  // default -> false

											 // Optional navigation (enable when AppUser is in your DbContext)
											 // [ForeignKey(nameof(UserId))]
											 // public AppUser? User { get; set; }
	}
}

