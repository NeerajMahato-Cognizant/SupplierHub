using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
	public class AdminRepository : IAdminRepository
	{
		private readonly AppDbContext _db;

		public AdminRepository(AppDbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Retrieves a system configuration by its ID.
		/// </summary>

		public Task<SystemConfig?> GetSystemConfigByIdAsync(long id) =>
			_db.SystemConfigs.FirstOrDefaultAsync(x => x.ConfigID == id);

		/// <summary>
		/// Retrieves a system configuration by its config key.
		/// </summary>

		public Task<SystemConfig?> GetSystemConfigByKeyAsync(string configKey) =>
			_db.SystemConfigs.FirstOrDefaultAsync(x => x.ConfigKey == configKey);

		/// <summary>
		/// Retrieves all system configurations.
		/// </summary>

		public Task<List<SystemConfig>> GetAllSystemConfigsAsync() =>
			_db.SystemConfigs.ToListAsync();

		/// <summary>
		/// Adds a new system configuration to the database.
		/// </summary>

		public async Task<SystemConfig> AddSystemConfigAsync(SystemConfig config)
		{
			_db.SystemConfigs.Add(config);
			await _db.SaveChangesAsync();
			return config;
		}

		/// <summary>
		/// Updates an existing system configuration in the database.
		/// </summary>

		public async Task<SystemConfig?> UpdateSystemConfigAsync(SystemConfig config)
		{
			_db.SystemConfigs.Update(config);
			await _db.SaveChangesAsync();
			return config;
		}

		/// <summary>
		/// Retrieves an approval rule by its ID.
		/// </summary>

		public Task<ApprovalRule?> GetApprovalRuleByIdAsync(long id) =>
			_db.ApprovalRules.FirstOrDefaultAsync(x => x.RuleID == id);

		/// <summary>
		/// Retrieves all approval rules.
		/// </summary>

		public Task<List<ApprovalRule>> GetAllApprovalRulesAsync() =>
			_db.ApprovalRules.ToListAsync();

		/// <summary>
		/// Retrieves all approval rules for a specific scope.
		/// </summary>

		public Task<List<ApprovalRule>> GetApprovalRulesByScopeAsync(string scope) =>
			_db.ApprovalRules.Where(x => x.Scope == scope).ToListAsync();

		/// <summary>
		/// Adds a new approval rule to the database.
		/// </summary>

		public async Task<ApprovalRule> AddApprovalRuleAsync(ApprovalRule rule)
		{
			_db.ApprovalRules.Add(rule);
			await _db.SaveChangesAsync();
			return rule;
		}

		/// <summary>
		/// Updates an existing approval rule in the database.
		/// </summary>

		public async Task<ApprovalRule?> UpdateApprovalRuleAsync(ApprovalRule rule)
		{
			_db.ApprovalRules.Update(rule);
			await _db.SaveChangesAsync();
			return rule;
		}

		/// <summary>
		/// Assigns a role to a user.
		/// </summary>
		public async Task<UserRole> AssignRoleAsync(long userID, long roleID)
		{
			try
			{
				// Verify User exists
				var user = await _db.Users.FirstOrDefaultAsync(u => u.UserID == userID);
				if (user == null)
					throw new InvalidOperationException($"User with ID {userID} does not exist.");

				// Verify Role exists
				var role = await _db.Roles.FirstOrDefaultAsync(r => r.RoleID == roleID);
				if (role == null)
					throw new InvalidOperationException($"Role with ID {roleID} does not exist.");

				// Check if assignment already exists
				var existingAssignment = await _db.UserRoles.FirstOrDefaultAsync(
					x => x.UserID == userID && x.RoleID == roleID);

				if (existingAssignment != null && !existingAssignment.IsDeleted)
					throw new InvalidOperationException($"User {userID} already has Role {roleID} assigned.");

				var userRole = new UserRole
				{
					UserID = userID,
					RoleID = roleID,
					Status = "ACTIVE",
					CreatedOn = DateTime.UtcNow,
					UpdatedOn = DateTime.UtcNow,
					IsDeleted = false
				};

				_db.UserRoles.Add(userRole);
				await _db.SaveChangesAsync();
				return userRole;
			}
			catch (DbUpdateException dbEx)
			{
				throw new InvalidOperationException(
					$"Database error while assigning role: {dbEx.InnerException?.Message}", dbEx);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException($"Error assigning role: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// Deletes/removes a role from a user (soft delete).
		/// </summary>
		public async Task<bool> DeleteRoleAsync(long userID, long roleID)
		{
			var userRole = await _db.UserRoles.FirstOrDefaultAsync(x => x.UserID == userID && x.RoleID == roleID);
			if (userRole == null) return false;

			userRole.IsDeleted = true;
			userRole.UpdatedOn = DateTime.UtcNow;

			_db.UserRoles.Update(userRole);
			await _db.SaveChangesAsync();
			return true;
		}

		/// <summary>
		/// Retrieves all roles assigned to a user.
		/// </summary>
		public Task<List<UserRole>> GetUserRolesAsync(long userID) =>
			_db.UserRoles.Where(x => x.UserID == userID && !x.IsDeleted).ToListAsync();
	}
}
