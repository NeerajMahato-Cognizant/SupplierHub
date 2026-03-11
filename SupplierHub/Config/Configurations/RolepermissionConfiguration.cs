using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class RolePermissionConfiguration : IEntityTypeConfiguration<Rolepermission>
	{
		public void Configure(EntityTypeBuilder<Rolepermission> builder)
		{
			builder.ToTable("role_permission");

			// Composite Primary Key
			builder.HasKey(x => new { x.RoleId, x.PermissionId })
				   .HasName("pk_role_permission");

			// Columns
			builder.Property(x => x.RoleId).IsRequired();
			builder.Property(x => x.PermissionId).IsRequired();

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasMaxLength(30)
				   .HasDefaultValue("ACTIVE");

			builder.Property(x => x.CreatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.UpdatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			// Helpful indexes
			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_role_permission_status");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
			// FOREIGN KEYS (enable these once Role & Permission entities exist)

			// builder.HasOne<Role>()
			//        .WithMany()
			//        .HasForeignKey(x => x.RoleId)
			//        .HasConstraintName("fk_role_permission_role");

			// builder.HasOne<Permission>()
			//        .WithMany()
			//        .HasForeignKey(x => x.PermissionId)
			//        .HasConstraintName("fk_role_permission_permission");
		}
	}
}
