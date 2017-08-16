using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Domain.Entity
{
    public class Endereco
    {
        //Assume a responsabilidade de PK e FK
        public int EnderecoId { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        //Não é necessário referenciar FK
        //em uma associação de 1..0 ou ..1
        //public int EstundateId { get; set; }
        public virtual Estudante Estudante { get; set; }
    }
}
