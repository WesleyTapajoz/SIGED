using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Domain.Entity
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public int TipoProfessor { get; set; }
        public int NivelEnsinoId { get; set; }
        public NivelEnsino NivelEnsino { get; set; }

    }
}
