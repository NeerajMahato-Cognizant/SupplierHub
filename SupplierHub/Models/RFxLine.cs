using SupplierHub.Constants.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class RFxLine
	{
		[Key]
		public int rfx_line_id { get; set; }

		[Required]
		public int rfx_id { get; set; }
		[ForeignKey("rfx_id")]
		public virtual RFxEvent RFxEvent { get; set; }

		public int item_id { get; set; }
		[ForeignKey(nameof(item_id))]
		public virtual Item Item { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal qty { get; set; }

		[Required]
		[StringLength(10)]
		public UOM uom { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? target_price { get; set; }

		public string notes { get; set; }

		public bool IsDeleted { get; set; } = false;

		public ICollection<BidLine> BidLines { get; set; }

	}
}
