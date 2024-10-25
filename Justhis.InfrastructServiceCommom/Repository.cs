using DomainCommon.Model;
using Justhis.InfrastructureCommon;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Justhis.InfrastructServiceCommom
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext DB;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(DbContext db, DbSet<TEntity> dbSet) 
        {
            DB = db;
            DbSet = dbSet;
        }

        public async Task AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            DB.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }

        public async Task UpdateAsync(TEntity obj)
        {
            DbSet.Update(obj);
            await Task.CompletedTask;
        }
    }
}
