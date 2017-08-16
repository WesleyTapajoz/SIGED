using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Interfaces.Repository;
using UFMT.SIGED.Infra.Data.Context;

namespace UFMT.SIGED.Infra.Data
{
    public class Repository<TEntity> :
        IRepository<TEntity> where TEntity : class
    {
        protected SIGEDContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(SIGEDContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return DbSet.Where(predicado);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
