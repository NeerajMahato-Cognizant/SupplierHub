using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;
namespace SupplierHub.Config.Configurations
{
	public class RFxEventConfiguration : IEntityTypeConfiguration<RFxEvent>
	{
		public void Configure(EntityTypeBuilder<RFxEvent> builder) {
			builder.Property(x => x.Type).HasDefaultValue("RFI");
			builder.Property(x => x.Status).HasDefaultValue("Open");

		}
	}
}
