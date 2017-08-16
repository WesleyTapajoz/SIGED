using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Infra.Data.EntityConfiguration
{
    public class ConfiguracaoCurso 
        : EntityTypeConfiguration<Curso>
    {
        public ConfiguracaoCurso()
        {
            Property(x => x.Descricao)
            .HasMaxLength(800);
        }
    }
}
