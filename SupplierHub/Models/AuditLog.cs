using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models.IAM
{
	[Table("AuditLogs")]
	public class AuditLog
	{
		[Key]
		public int AuditId { get; set; }

		public int? UserId { get; set; }

		[Required, MaxLength(80)]
		public string Action { get; set; } = string.Empty; // e.g., CREATE, UPDATE, DELETE, LOGIN

		[Required, MaxLength(120)]
		public string Resource { get; set; } = string.Empty; // e.g., User, Role

		[Required]
		public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

		public string? MetadataJson { get; set; }
	}
}
