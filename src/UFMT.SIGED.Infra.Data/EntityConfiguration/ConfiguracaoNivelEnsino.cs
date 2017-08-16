using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Infra.Data.EntityConfiguration
{
    public class ConfiguracaoNivelEnsino 
        : EntityTypeConfiguration<NivelEnsino>
    {
        public ConfiguracaoNivelEnsino()
        {
            ToTable("Escolaridade");
            Property(p => p.Descricao).IsRequired();
            Property(p => p.Descricao).HasMaxLength(300);
            HasKey(p => p.NivelEnsinoId);

            HasMany(e => e.Estudantes)
            .WithRequired(n => n.NivelEnsino)
            .HasForeignKey(n => n.NivelEnsinoId)
            .WillCascadeOnDelete(false);
        }
    }
}
