using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplierHub.Constants.Enum;
using SupplierHub.Models;

namespace SupplierHub.Models
{
	public class RFxEvent
	{
		[Key]
		public int rfx_id { get; set; }

		[Required]
		public RFxType type { get; set; } 

		[Required]
		[StringLength(200)]
		public string? title { get; set; }
		
		public int category_id { get; set; }
		[ForeignKey(nameof(category_id))]

		public Category Category { get; set; }


		public int created_by { get; set; }
		[ForeignKey(nameof(created_by))]

		public virtual User? User { get; set; }


		[Required]
		public DateTime open_date { get; set; }

		[Required]
		public DateTime close_date { get; set; }

		[Required]
		[StringLength(20)]
		public RFxStatus status { get; set; }

		public bool IsDeleted { get; set; } = false;

		public Award Award { get; set; }
		public virtual ICollection<RFxLine> RFxLines { get; set; }
		public virtual ICollection<RFxInvite> RFxInvites { get; set; }
		public virtual ICollection<Bid> Bids { get; set; }


	}
}
