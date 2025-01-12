using DevIO.Business.Core.Data;
using DevIO.Business.Core.Models;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext db;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(AppDbContext _db)
        {
            db = _db;
            dbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            db.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
