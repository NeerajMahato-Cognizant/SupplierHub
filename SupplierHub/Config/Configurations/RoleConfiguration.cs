using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;
using System.Data;

namespace SupplierHub.Config.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("role");

			builder.HasKey(x => x.RoleId)
				   .HasName("pk_role");

			builder.Property(x => x.Name)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(x => x.Description)
				   .HasMaxLength(255);

			// Enum stored as string (consistent with your other entities)
			// DB sheet shows default 'ACTIVE' — we map enum name "Active" as default here.
			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(30)
				   .HasDefaultValue("Active");

			builder.Property(x => x.CreatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.UpdatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			// Indexes
			builder.HasIndex(x => x.Name)
				   .IsUnique()
				   .HasDatabaseName("uq_role_name");

			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_role_status");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}
