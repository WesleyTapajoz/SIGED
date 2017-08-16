using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;

namespace UFMT.SIGED.Infra.Data.EntityConfiguration
{
    public class ConfiguracaoEstudante 
        : EntityTypeConfiguration<Estudante>
    {
        public ConfiguracaoEstudante()
        {
            //Configura one-to-zero-or-one
                 HasOptional(end => end.Endereco)
                .WithRequired(est => est.Estudante);

            HasMany(e => e.Cursos)
                .WithMany(e => e.Estudantes)
                .Map(ce => {
                    ce.MapLeftKey("EstudanteId");
                    ce.MapRightKey("CursoId");
                    ce.ToTable("EstudanteCurso");
                });

            //MapToStoredProcedures();
            MapToStoredProcedures(
                    p =>
                         p.Insert(spi =>
                                  spi.HasName("spInserirEstudante")
                                    .Parameter(pmi => pmi.Nome, "nome")
                                    .Result(ri => ri.EstudanteId, "estudanteId")
                                 )
                         .Update(spu => spu.HasName("spAtualizarEstudante")
                                         .Parameter(pmu => pmu.Nome, "nome"))
                         .Delete(spd => spd.HasName("spExcluirEstudante")
                                         .Parameter(pmd => pmd.EstudanteId, "estudanteId"))

                );

        }
    }
}
