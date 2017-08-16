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
    public class EstudanteRepository
        : Repository<Estudante>, IEstudanteRepository
    {
        public EstudanteRepository(SIGEDContext context) 
            : base(context)
        {
        }

      }
}
