using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupplierHub.Models;
using SupplierHub.Repositories.Interface;

namespace SupplierHub.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _db;

		public UserRepository(AppDbContext db)
		{
			_db = db;
		}

		public async Task<List<User>> GetAllAsync(bool includeDeleted = false, CancellationToken ct = default)
		{
			var query = _db.Users.AsQueryable();
			if (!includeDeleted)
				query = query.Where(u => !u.IsDeleted);

			return await query.OrderByDescending(u => u.CreatedOn).ToListAsync(ct);
		}

		public async Task<User?> GetByIdAsync(long id, bool includeDeleted = false, CancellationToken ct = default)
		{
			var entity = await _db.Users.FirstOrDefaultAsync(u => u.UserID == id, ct);
			if (entity == null) return null;
			if (!includeDeleted && entity.IsDeleted) return null;
			return entity;
		}

		public async Task AddAsync(User entity, CancellationToken ct = default)
		{
			await _db.Users.AddAsync(entity, ct);
		}

		public Task UpdateAsync(User entity, CancellationToken ct = default)
		{
			_db.Users.Update(entity);
			return Task.CompletedTask;
		}

		public async Task<bool> SoftDeleteAsync(long id, CancellationToken ct = default)
		{
			var entity = await _db.Users.FirstOrDefaultAsync(u => u.UserID == id, ct);
			if (entity == null || entity.IsDeleted) return false;
			entity.IsDeleted = true;
			entity.UpdatedOn = System.DateTime.UtcNow;
			return true;
		}

		public Task<int> SaveChangesAsync(CancellationToken ct = default)
		{
			return _db.SaveChangesAsync(ct);
		}

		public async Task<bool> ExistsAsync(long id, bool includeDeleted = false, CancellationToken ct = default)
		{
			var entity = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserID == id, ct);
			if (entity == null) return false;
			if (!includeDeleted && entity.IsDeleted) return false;
			return true;
		}

		// Added: include user roles and role navigation when fetching by email.
		public async Task<User?> GetByEmailWithRolesAsync(string email, bool includeDeleted = false, CancellationToken ct = default)
		{
			if (string.IsNullOrWhiteSpace(email)) return null;

			var lower = email.Trim().ToLowerInvariant();

			var query = _db.Users
				.Include(u => u.UserRoles!)
					.ThenInclude(ur => ur.Role)
				.AsQueryable();

			var entity = await query.FirstOrDefaultAsync(u => u.Email.ToLower() == lower, ct);
			if (entity == null) return null;
			if (!includeDeleted && entity.IsDeleted) return null;
			return entity;
		}
	}
}