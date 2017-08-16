using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Application.ViewModels
{
    public class AdicionarNivelEnsinoViewModel
    {
        [Key]
        public int NivelEnsinoId { get; set; }
        [Required(ErrorMessage = "Descrição Obrigatório")]
        [StringLength(50, 
            ErrorMessage = "Máximo de 50 caracteres")]
        public string Descricao { get; set; }
    }
}
