using SupplierHub.Constants.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierHub.Models
{
	public class RFxInvite
	{
		[Key]
		public int invite_id { get; set; }

		[Required]
		public int rfx_id { get; set; }
		[ForeignKey("rfx_id")]
		public virtual RFxEvent RFxEvent { get; set; }

		public int supplier_id { get; set; }
		[ForeignKey(nameof(supplier_id))]  
		public virtual Supplier Supplier { get; set; }

		

		public DateTime invited_date { get; set; } = DateTime.Now;

		[StringLength(20)]
		public InviteStatus status { get; set; }

		public bool IsDeleted { get; set; } = false;
	}
}
