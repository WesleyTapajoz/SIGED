using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Domain.Interfaces.Repository;
using UFMT.SIGED.Infra.Data.Context;

namespace UFMT.SIGED.Infra.Data
{
    public class NivelEnsinoRepository
        : Repository<NivelEnsino>, INivelEnsinoRepository
    {
        public NivelEnsinoRepository(SIGEDContext context) 
            : base(context)
        {
        }

        public NivelEnsino ObterPorDescricao(
            string descricao)
        {
            return DbSet
                .Where(q => q.Descricao == descricao)
                .FirstOrDefault();
        }
    }
}
