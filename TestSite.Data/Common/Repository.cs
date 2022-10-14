using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestSite.Data.Entities;

namespace TestSite.Data.Common;

public class Repository : IRepository {

	public Repository(ApplicationDbContext context) => Context = context;

	protected DbContext Context { get; set; }

	public async Task AddAsync<T>(T entity) where T : class => await DbSet<T>().AddAsync(entity);

	public async Task AddSaveAsync<T>(T entity) where T : class {
		DbSet<T>().Add(entity);
		await SaveChangesAsync();
	}

	public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class =>
		await DbSet<T>().AddRangeAsync(entities);

	public IQueryable<T> All<T>() where T : class => DbSet<T>().AsQueryable();

	public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class => DbSet<T>().Where(search);

	public IQueryable<T> AllReadonly<T>() where T : class => DbSet<T>().AsNoTracking();

	public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class =>
		DbSet<T>().Where(search).AsNoTracking();

	public async Task DeleteAsync<T>(object id) where T : class => Delete(await GetByIdAsync<T>(id));

	public async Task DeleteSaveAsync<T>(object id) where T : class {
		DeleteAsync<T>(id);
		await SaveChangesAsync();
	}

	public async Task<T> GetByIdAsync<T>(object id) where T : class => await DbSet<T>().FindAsync(id);

	public async Task<T> GetByIdsAsync<T>(object[] id) where T : class => await DbSet<T>().FindAsync(id);

	public void Update<T>(T entity) where T : class => DbSet<T>().Update(entity);

	public async Task UpdateSaveAsync<T>(T entity) where T : class {
		Update<T>(entity);
		await SaveChangesAsync();
	}

	public void UpdateRange<T>(IEnumerable<T> entities) where T : class => DbSet<T>().UpdateRange(entities);

	public void DeleteRange<T>(IEnumerable<T> entities) where T : class => DbSet<T>().RemoveRange(entities);

	public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class =>
		DeleteRange(All(deleteWhereClause));

	public void Delete<T>(T entity) where T : class {
		EntityEntry entry = Context.Entry(entity);

		if (entry.State == EntityState.Detached)
			DbSet<T>().Attach(entity);

		entry.State = EntityState.Deleted;
	}

	public void Detach<T>(T entity) where T : class => Context.Entry(entity).State = EntityState.Detached;

	public void Dispose() => Context.Dispose();

	protected DbSet<T> DbSet<T>() where T : class => Context.Set<T>();

	public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();

}