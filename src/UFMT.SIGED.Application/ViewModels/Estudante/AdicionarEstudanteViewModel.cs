using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Application.ViewModels
{
    public class AdicionarEstudanteViewModel
    {
        [Key]
        public int EstudanteId { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Altura obrigatório")]
        public decimal Altura { get; set; }
        [Required(ErrorMessage = "Peso obrigatório")]
        public decimal Peso { get; set; }
        [Required(ErrorMessage = "Data de nascimento obrigatório")]
        public DateTime DataNascimento { get; set; }
        public byte[] Foto { get; set; }
        public int NivelEnsinoId { get; set; }
        public NivelDeEnsinoViewModel NivelEnsino { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
