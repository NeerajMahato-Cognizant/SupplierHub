using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class AppUserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("user");

			builder.HasKey(x => x.AppUserId)
				   .HasName("pk_user");

			builder.Property(x => x.OrgId)
				   .IsRequired();

			builder.Property(x => x.Name)
				   .IsRequired()
				   .HasMaxLength(150);

			builder.Property(x => x.Email)
				   .IsRequired()
				   .HasMaxLength(150);

			builder.Property(x => x.Phone)
				   .HasMaxLength(30);

			builder.Property(x => x.PasswordHash)
				   .HasMaxLength(255);

			// Enum stored as string, with default "Active" (sheet shows 'ACTIVE')
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
			builder.HasIndex(x => x.Email)
				   .IsUnique()
				   .HasDatabaseName("uq_user_email");

			builder.HasIndex(x => x.OrgId)
				   .HasDatabaseName("idx_user_org");

			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_user_status");

			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");
			// Foreign Key (uncomment when Organization model exists & is registered)
			// builder.HasOne<Organization>()
			//        .WithMany()
			//        .HasForeignKey(x => x.OrgId)
			//        .HasConstraintName("fk_user_organization");
		}
	}
}
