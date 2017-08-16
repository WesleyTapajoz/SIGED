using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity
            , bool>> predicado);
        void Remover(int id);

    }
}
