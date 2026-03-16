using System;
using System.ComponentModel.DataAnnotations;

namespace SupplierHub.Models
{
	public class Requisition
	{
		[Key]
		public long PrID { get; set; }

		[Required]
		public long RequesterID { get; set; }

		[Required]
		public long OrgID { get; set; }

		[MaxLength(50)]
		public string? CostCenter { get; set; }

		[MaxLength(500)]
		public string? Justification { get; set; }

		public DateTime? RequestedDate { get; set; }

		public DateTime? NeededByDate { get; set; }

		[Required, MaxLength(30)]
		public required string Status { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

<<<<<<< HEAD
		public bool IsDeleted { get; set; }  // default -> false

		// Navigation Properties
		public virtual User Requester { get; set; }
=======
		[Required]
		public DateTime UpdatedOn { get; set; }
>>>>>>> f5b24b19b20cc4f606a8ea7902667aadcbaffb0f

		[Required]
		public bool IsDeleted { get; set; }
	}
}