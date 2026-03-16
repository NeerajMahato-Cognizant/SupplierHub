using SupplierHub.Constants.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class Bid
	{
		[Key]
		public int bid_id { get; set; }

		[Required]
		public int rfx_id { get; set; }
		[ForeignKey("rfx_id")]
		public virtual RFxEvent RFxEvent { get; set; }

		public int supplier_id { get; set; }
		[ForeignKey(nameof(supplier_id))]

		public virtual Supplier Supplier { get; set; }

		public DateTime bid_date { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal total_value { get; set; }

		[StringLength(3)]
		public string currency { get; set; } 

		[StringLength(20)]
		public BidStatus status { get; set; }

		public bool IsDeleted { get; set; } = false;

		public virtual ICollection<BidLine> BidLines { get; set; }
	}
}
