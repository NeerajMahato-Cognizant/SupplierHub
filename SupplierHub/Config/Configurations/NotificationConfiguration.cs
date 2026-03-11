using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
	{
		public void Configure(EntityTypeBuilder<Notification> builder)
		{
			builder.ToTable("Notification");

			// Core columns
			builder.Property(x => x.UserId).IsRequired();

			builder.Property(x => x.Message)
				   .IsRequired()
				   .HasMaxLength(500); // adjust if you prefer a different limit

			// Enums as string (consistent with your UserConfiguration style)
			builder.Property(x => x.Category)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(30);

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(20)
				   .HasDefaultValue("Unread");

			// Timestamps
			builder.Property(x => x.CreatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.UpdatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			// Indexes
			builder.HasIndex(x => x.UserId).HasDatabaseName("idx_notification_user");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_notification_status");
			builder.HasIndex(x => x.Category).HasDatabaseName("idx_notification_category");
			builder.HasIndex(x => x.CreatedOn).HasDatabaseName("idx_notification_createdon");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
		}
	}
}

