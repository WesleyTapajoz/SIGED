using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Application.ViewModels
{
    public class NivelDeEnsinoViewModel
    {
        public int NivelEnsinoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Estudante> Estudantes { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }
    }
}
