using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class AppNotificationConfiguration : IEntityTypeConfiguration<Notification>
	{
		public void Configure(EntityTypeBuilder<Notification> builder)
		{
			builder.ToTable("notification");

			builder.HasKey(x => x.NotificationId)
				   .HasName("pk_notification");

			builder.Property(x => x.UserId)
				   .IsRequired();

			builder.Property(x => x.Message)
				   .IsRequired()
				   .HasMaxLength(500);

			// Enums stored as string to match VARCHAR(30) columns from the sheet
			builder.Property(x => x.Category)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(30);

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasConversion<string>()
				   .HasMaxLength(30)
				   .HasDefaultValue("Unread");

			builder.Property(x => x.RefEntityId);

			// Defaults – SQL Server. If using MySQL, see note below to switch to CURRENT_TIMESTAMP.
			builder.Property(x => x.CreatedDate)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.CreatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.UpdatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			// Indexes to support common queries
			builder.HasIndex(x => x.UserId).HasDatabaseName("idx_notification_user");
			builder.HasIndex(x => x.Status).HasDatabaseName("idx_notification_status");
			builder.HasIndex(x => x.Category).HasDatabaseName("idx_notification_category");
			builder.HasIndex(x => x.CreatedDate).HasDatabaseName("idx_notification_createddate");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
			// Foreign key (enable when AppUser is in your DbContext)
			// builder.HasOne<AppUser>()
			//        .WithMany()
			//        .HasForeignKey(x => x.UserId)
			//        .HasConstraintName("fk_notification_user");
		}
	}
}

