using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Application.ViewModels
{
    public class LoginUsuarioViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int UsuarioId { get; set; }
        [ScaffoldColumn(false)]
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "{0} no formato inválido")]
        public string Email { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public NivelAcessoSistema NivelAcesso { get; set; }
        [ScaffoldColumn(false)]
        public DateTime UltimoAcesso { get; set; }
        [ScaffoldColumn(false)]
        public bool Bloqueado { get; set; }
    }
}
