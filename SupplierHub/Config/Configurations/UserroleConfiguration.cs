using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierHub.Models;

namespace SupplierHub.Config.Configurations
{
	public class UserRoleLinkConfiguration : IEntityTypeConfiguration<Userrole>
	{
		public void Configure(EntityTypeBuilder<Userrole> builder)
		{
			builder.ToTable("user_role");

			// Composite key
			builder.HasKey(x => new { x.UserId, x.RoleId })
				   .HasName("pk_user_role");

			// Column requirements
			builder.Property(x => x.UserId).IsRequired();
			builder.Property(x => x.RoleId).IsRequired();

			builder.Property(x => x.Status)
				   .IsRequired()
				   .HasMaxLength(30)
				   .HasDefaultValue("ACTIVE");

			// Timestamps
			builder.Property(x => x.CreatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.UpdatedOn)
				   .IsRequired()
				   .HasDefaultValueSql("GETUTCDATE()");

			builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
			// Indexes (helpful filters)
			builder.HasIndex(x => x.Status)
				   .HasDatabaseName("idx_user_role_status");
			builder.HasIndex(x => x.IsDeleted).HasDatabaseName("idx_contract_isdeleted");

			// Foreign keys (uncomment when you have Role entity and want FK constraints)
			// builder.HasOne<User>()
			//        .WithMany() // Or .WithMany(u => u.UserRoles) if you add a collection nav
			//        .HasForeignKey(x => x.UserId)
			//        .HasConstraintName("fk_user_role_user");

			// builder.HasOne<Role>()
			//        .WithMany()
			//        .HasForeignKey(x => x.RoleId)
			//        .HasConstraintName("fk_user_role_role");
		}
	}
}
