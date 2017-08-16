using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFMT.SIGED.Domain.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UFMT.SIGED.Infra.Data.EntityConfiguration;

namespace UFMT.SIGED.Infra.Data.Context
{
    public class SIGEDContext : DbContext
    {
        public SIGEDContext() 
            :base("name=strConexaoSIGED")
        {
           //TODO: implementar estratégia
           //de inicialização do EF
        }

        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<NivelEnsino> NiveisDeEnsino { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating
            (DbModelBuilder modelBuilder)
        {
            #region Configurações gerais do EF
            modelBuilder
                .Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder
                .Conventions
                .Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder
               .Conventions
               .Remove<PluralizingTableNameConvention>();

            //Utilizando o Fluent API para configurar
            //o mapeamento do tipo string para o varchar
            modelBuilder.Properties<string>()
            .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
            .Configure(x => x.HasMaxLength(200));

            modelBuilder.Types()
                .Configure(t => t.MapToStoredProcedures());

            #endregion

            #region Adicionando as classes de configuração do EF
            modelBuilder.Configurations
                .Add(new ConfiguracaoEstudante());

            modelBuilder.Configurations
                .Add(new ConfiguracaoCurso());

            modelBuilder.Configurations
                .Add(new ConfiguracaoNivelEnsino());

            modelBuilder.Configurations
                .Add(new ConfiguracaoProfessor());

        #endregion

        }
    }
}
