using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;
using System.Security;

namespace SupplierHub.Config.Configurations
{
	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.ToTable("permission");

			builder.HasKey(x => x.PermissionId)
				   .HasName("pk_permission");

			builder.Property(x => x.Code)
				   .IsRequired()
				   .HasMaxLength(120);

			builder.Property(x => x.Name)
				   .IsRequired()
				   .HasMaxLength(150);

			builder.Property(x => x.Description)
				   .HasMaxLength(255);

			// Enum as string (consistent with your other tables)
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
			builder.HasIndex(x => x.Code)
				   .IsUnique()
				   .HasDatabaseName("uq_permission_code");

			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_permission_status");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}
