using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class AppAuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
	{
		public void Configure(EntityTypeBuilder<AuditLog> builder)
		{
			builder.ToTable("audit_log");

			builder.HasKey(x => x.AuditId)
				   .HasName("pk_audit_log");

			builder.Property(x => x.UserId);

			builder.Property(x => x.Action)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(x => x.Resource)
				   .IsRequired()
				   .HasMaxLength(200);

			builder.Property(x => x.MetadataJson);

			// Defaults (SQL Server). If you are on MySQL, see note below.
			builder.Property(x => x.Timestamp)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

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
			// Helpful indexes
			builder.HasIndex(x => x.Timestamp).HasDatabaseName("idx_audit_log_timestamp");
			builder.HasIndex(x => x.UserId).HasDatabaseName("idx_audit_log_user");
			builder.HasIndex(x => x.Resource).HasDatabaseName("idx_audit_log_resource");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_audit_log_status");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
			// Foreign key (enable when AppUser entity is registered in DbContext)
			// builder.HasOne<AppUser>()
			//        .WithMany()
			//        .HasForeignKey(x => x.UserId)
			//        .HasConstraintName("fk_audit_log_user");
		}
	}
}
