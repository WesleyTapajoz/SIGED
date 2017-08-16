using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Application.ViewModels
{
    public class EstudanteNivelEnsinoViewModel
    {
        public int EstudanteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NivelEnsinoId { get; set; }
        public string Descricao { get; set; }
        public int TotalEstudantes { get; set; }

    }
}
