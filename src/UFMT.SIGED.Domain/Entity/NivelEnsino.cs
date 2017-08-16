using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Domain.Entity
{
    public class NivelEnsino
    {
        public int NivelEnsinoId { get; set; }
        public string Descricao { get; set; }
        //virtual para Lazy Loading
        public virtual ICollection<Estudante> Estudantes { get; set; }
        public virtual ICollection<Professor> Professores{ get; set; }
    }
}
